using Client.Base.Controllers;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class ApproverController : BaseController<UserRequest, ApproverRepository, int>
    {
        private readonly ApproverRepository repository;

        public ApproverController(ApproverRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        [Authorize(Roles = "Approver Finance")]
        public IActionResult Index()
        {
            ViewBag.userId = HttpContext.Session.GetString("UserId");
            return View();
        }
        [HttpGet("GetById/{ID}")]
        public async Task<JsonResult> GetById(string id)
        {
            var result = await repository.GetById(id);
            return Json(result);
        }
        [HttpGet("GetAllData")]
        public async Task<JsonResult> GetAllData()
        {
            var result = await repository.GetAllUserRequest();
            return Json(result);
        }
        [HttpPost("PostUserReq")]
        public JsonResult PostUserRequest( UserRequest userRequest)
        {
            var result = repository.PostUserRequest(userRequest);
            return Json(result);
        }
        
    }
}

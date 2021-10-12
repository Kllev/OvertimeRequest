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
    public class UserRequestController : BaseController<UserRequest, UserRequestRepository, int>
    {
        private readonly UserRequestRepository repository;

        public UserRequestController(UserRequestRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        [Authorize]
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

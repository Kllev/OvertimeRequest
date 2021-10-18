using Client.Base.Controllers;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class StatusController : BaseController<Request, StatusRepository, string>
    {
        StatusRepository statusRepository;
        public StatusController(StatusRepository repository) : base(repository)
        {
            this.statusRepository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.userId = HttpContext.Session.GetString("UserId");
            return View();
        }

        [HttpGet("GetReqUserById/{ID}")]
        public async Task<JsonResult> GetById(string id)
        {
            var result = await statusRepository.GetById(id);
            return Json(result);
        }
    }
}

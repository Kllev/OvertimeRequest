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
    public class HistoryController : BaseController<Request, HistoryRepository, int>
    {
        HistoryRepository historyRepository;
        public HistoryController(HistoryRepository repository) : base(repository)
        {
            this.historyRepository = repository;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.userId = HttpContext.Session.GetString("UserId");
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public async Task<JsonResult> GetHistory()
        {
            var result = await historyRepository.GetHistory();
            return Json(result);
        }
    }
}

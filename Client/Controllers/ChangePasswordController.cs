using Client.Base.Controllers;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overtime.Models;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class ChangePasswordController : BaseController<Account, ChangePasswordRepository, string>
    {
        ChangePasswordRepository changePasswordRepository;

        public ChangePasswordController(ChangePasswordRepository repository) : base(repository)
        {
            this.changePasswordRepository = repository;
        }
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.email = HttpContext.Session.GetString("Email");
            return View();
        }

        [HttpPost]
        public JsonResult Change(LoginVM loginVM)
        {
            var result = changePasswordRepository.ChangePassword(loginVM);
            return Json(result);
        }
    }
}
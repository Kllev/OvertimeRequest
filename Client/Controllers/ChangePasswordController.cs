using Client.Base.Controllers;
using Client.Repositories.Data;
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
        ChangePasswordRepository repository;

        public ChangePasswordController(ChangePasswordRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("ChangePassword")]
        public JsonResult ChangePassword(LoginVM loginVM)
        {
            var result = repository.ChangePassword(loginVM);
            return Json(result);
        }

    }
}

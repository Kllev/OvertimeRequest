using Client.Base.Controllers;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Overtime.Models;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class ForgotPasswordController : BaseController<Account, ForgotPasswordRepository, string>
    {
        ForgotPasswordRepository forgotPassword;
        public ForgotPasswordController(ForgotPasswordRepository repository) : base(repository)
        {
            this.forgotPassword = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Forgot(LoginVM loginVM)
        {
            var result = forgotPassword.ForgotPassword(loginVM);
            return Json(result);
        }
    }
}

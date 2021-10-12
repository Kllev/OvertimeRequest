using Client.Models;
using Client.Base.Controllers;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Overtime.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Client.Controllers
{
    public class LoginController : BaseController<Account, LoginRepository, string>
    {
        LoginRepository loginRepository;
        private object jwtHandler;

        public LoginController(LoginRepository loginRepository) : base(loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        [HttpPost("Auth/")]
        public async Task<IActionResult> Auth(string email, string password)
        {
            LoginVM loginVM = new LoginVM();
            loginVM.Email = email;
            loginVM.Password = password;
            var jwtToken = await loginRepository.Auth(loginVM);
            var token = jwtToken.Token;
            var employeeId = jwtToken.Id;
            var firstName = jwtToken.firstName;

            if (token == null)
            {
                return RedirectToAction("index");
            }

            HttpContext.Session.SetString("JWToken", token);
            HttpContext.Session.SetString("UserId", employeeId);
            HttpContext.Session.SetString("FirstName", firstName);

            //HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        [HttpGet("Logout/")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

using Client.Base.Controllers;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Overtime.Models;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class RegisterController : BaseController<User, UserRepository, string>
    {
        UserRepository userRepository;
        public RegisterController(UserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("RegisterData/")]
        public JsonResult RegisterData([FromBody] RegisterVM register)
        {
            var result = userRepository.Register(register);
            return Json(result);
        }
    }
}

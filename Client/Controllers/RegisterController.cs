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

        [HttpGet("GetAllData")]
        public async Task<JsonResult> GetAllData()
        {
            var result = await userRepository.GetAllProfile();
            return Json(result);
        }

        [HttpGet("GetById/{nik}")]
        public async Task<JsonResult> GetById(string nik)
        {
            var result = await userRepository.GetById(nik);
            return Json(result);
        }

        [HttpPost]
        public JsonResult RegisterData(RegisterVM register)
        {
            var result = userRepository.Register(register);
            return Json(result);
        }
    }
}

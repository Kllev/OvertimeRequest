using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overtime.Base;
using Overtime.Models;
using Overtime.Repository.Data;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Overtime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User, UserRepository, string>
    {
        UserRepository userRepository;
        public UsersController(UserRepository repository) : base(repository)
        {
            this.userRepository = repository;
        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterVM register)
        {
            var regis = userRepository.Register(register);
            try
            {
                if (regis == 100)
                {
                    return BadRequest(new
                    {
                        status = HttpStatusCode.BadRequest,
                        message = "Email Sudah Terdaftar"
                    });
                }
                else if (regis == 200)
                {
                    return BadRequest(new
                    {
                        status = HttpStatusCode.BadRequest,
                        message = "UserID Sudah Terdaftar"
                    });
                }
                else if (regis == 300)
                {
                    return BadRequest(new
                    {
                        status = HttpStatusCode.BadRequest,
                        message = "Nomor Telepon Sudah Terdaftar"
                    });
                }
            }
            catch
            {

            }
            return Ok(userRepository.Get(register.userID));
        }
    }
}

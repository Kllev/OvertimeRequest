using Microsoft.AspNetCore.Cors;
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
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRequestsController : BaseController<UserRequest, UserRequestRepository, int>
    {
        UserRequestRepository repository;
        public UserRequestsController(UserRequestRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        [HttpPost("InsertUserReq")]
        public ActionResult InsertUserReq(RequestVM requestVM)
        {
            try
            {
                if (repository.InsertUserReq(requestVM) > 0)
                {
                    return Ok(new { status = HttpStatusCode.OK, message = "Data Berhasil ditambahkan" });
                }
                else if (repository.InsertUserReq(requestVM) == 0)
                {
                    return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Gagal Menambahkan Data" });
                }
                else
                {
                    return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Sudah ada" });
                }
            }
            catch (Exception e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    status = (int)HttpStatusCode.InternalServerError,
                    message = e.InnerException.Message
                });
            }
        }
    }
}

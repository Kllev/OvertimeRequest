using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Repository.StaticMethod;
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
    public class RequestsController : BaseController<Request, RequestRepository, int>
    { 
        RequestRepository requestrepository;
        public RequestsController(RequestRepository repository) : base(repository)
        {
            this.requestrepository = repository;
        }

        [HttpPut("Approve")]
        public ActionResult Approve(UpdateStatusVM updateStatusVM)
        {
            try
            {
                string GetDate = DateTime.Now.ToString();
                string SubjectMail = $"Update Request Status - {GetDate}";
                var get = requestrepository.Approve(updateStatusVM);
                EmailSender.SendEmail(updateStatusVM.Email, SubjectMail, "Hello "
                                  + updateStatusVM.Email + "<br><br>Kami informasikan bahwa Status Request Overtime anda sudah di approve <br><br><b>"+
                                   "<b><br><br>Thanks<br>OvertimeRequestTeam");
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.BadRequest,
                    Message = e
                });
            }
        }

        [HttpPut("Decline")]
        public ActionResult Decline(UpdateStatusVM updateStatusVM)
        {
            try
            {
                string GetDate = DateTime.Now.ToString();
                string SubjectMail = $"Update Request Status - {GetDate}";
                var get = requestrepository.Decline(updateStatusVM);
                EmailSender.SendEmail(updateStatusVM.Email, SubjectMail, "Hello "
                                  + updateStatusVM.Email + "<br><br>Kami informasikan bahwa Status Request Overtime anda ditolak <br><br><b>" +
                                   "<b><br><br>Thanks<br>OvertimeRequestTeam");
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new 
                {
                    status = HttpStatusCode.BadRequest,
                    Message = e
                });
            }
        }
        [HttpGet("GetReq/{id}")]
        public ActionResult GetUserReq(string id)
        {
            var getRegister = requestrepository.GetReqByManagerId(id);
            if (getRegister == null)
            {
                return NotFound(getRegister);
            }
            else
            {
                return Ok(getRegister);
            }
        }

        [HttpGet("GetRequest/{id}")]
        public ActionResult GetReqRequester(string id)
        {
            var getRegister = requestrepository.GetReqByReqId(id);
            if (getRegister == null)
            {
                return NotFound(getRegister);
            }
            else
            {
                return Ok(getRegister);
            }

        }
        [HttpGet("GetAllApproved")]
        public ActionResult AllApproved()
        {

            var get = requestrepository.GetAllApprove();
            if (get != null)
            {
                return Ok(get);
            }

            return NotFound("Tidak ada Data");

        }
    }
}

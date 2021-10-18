using Client.Base.Controllers;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Overtime.Models;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class RequestController : BaseController<Request, RequestRepository, int>
    {
        RequestRepository requestRepository;
        public RequestController(RequestRepository repository) : base(repository)
        {
            this.requestRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Status()
        {
            return View();
        }

        [HttpPut]
        public JsonResult Approve(UpdateStatusVM updateStatusVM )
        {
            var result = requestRepository.Approve(updateStatusVM);
            return Json(result);
        }

        [HttpPut]
        public JsonResult Decline(UpdateStatusVM updateStatusVM)
        {
            var result = requestRepository.Decline(updateStatusVM);
            //EmailSender.SendEmail(loginVM.Email, SubjectMail, "Hello "
            //                  + loginVM.Email + "<br><br>berikut Kode OTP anda<br><br><b>"
            //                  + otp + "<b><br><br>Thanks<br>netcore-api.com");
            return Json(result);
        }

        [HttpDelete]
        public JsonResult DeleteReq(int id)
        {
            var result = requestRepository.DeleteReq(id);
            return Json(result);
        }
    }
}

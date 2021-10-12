using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class ChangePasswordController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.email = HttpContext.Session.GetString("Email");
            return View();
        }
    }
}

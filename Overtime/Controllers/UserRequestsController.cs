using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overtime.Base;
using Overtime.Models;
using Overtime.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRequestsController : BaseController<UserRequest, UserRequestRepository, int>
    {
        public UserRequestsController(UserRequestRepository repository) : base(repository)
        {
        }
    }
}

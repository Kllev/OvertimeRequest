using Overtime.Context;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Repository.Data
{
    public class UserRequestRepository : GeneralRepository<MyContext, UserRequest, int>
    {
        public UserRequestRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}

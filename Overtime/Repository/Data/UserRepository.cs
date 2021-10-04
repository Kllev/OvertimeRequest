using Overtime.Context;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, string>
    {
        public UserRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}

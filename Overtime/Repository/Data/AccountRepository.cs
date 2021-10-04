using Overtime.Context;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        public AccountRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}

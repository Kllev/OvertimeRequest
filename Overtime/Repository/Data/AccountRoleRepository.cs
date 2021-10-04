using Overtime.Context;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<MyContext, AccountRole, int>
    {
        public AccountRoleRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}

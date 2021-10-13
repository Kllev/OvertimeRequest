using Overtime.Context;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Repository.Data
{
    public class RequestRepository : GeneralRepository<MyContext, Request, int>
    {
        public RequestRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}

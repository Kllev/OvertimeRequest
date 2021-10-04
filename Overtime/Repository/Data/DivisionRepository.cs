using Overtime.Context;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Repository.Data
{
    public class DivisionRepository : GeneralRepository<MyContext, Division, int>
    {
        public DivisionRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}

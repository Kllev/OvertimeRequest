using Overtime.Context;
using Overtime.Models;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Repository.Data
{
    public class RequestRepository : GeneralRepository<MyContext, Request, int>
    {
        MyContext myContext;
        public RequestRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public int Approve(UpdateStatusVM updateStatusVM)
        {
            var data = myContext.Requests.Where(x => x.Id.Equals(updateStatusVM.Id)).FirstOrDefault();
            data.StatusName = (Request.Status)0;
            myContext.Requests.Update(data);
            return myContext.SaveChanges();
        }
        public int Decline(UpdateStatusVM updateStatusVM)
        {
            var data = myContext.Requests.Where(x => x.Id.Equals(updateStatusVM.Id)).FirstOrDefault();
            data.StatusName = (Request.Status)1;
            myContext.Requests.Update(data);
            return myContext.SaveChanges();
        }
    }
}

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
        public IEnumerable<ListGetReqByManagerVM> GetReqByManagerId(string id)
        {
            var getData = (from u in myContext.Users
                           join ur in myContext.UserRequests on u.Id equals ur.UserId
                           join r in myContext.Requests on ur.RequestId equals r.Id
                           where u.ManagerID == id
                           select new ListGetReqByManagerVM
                           {
                               Id =r.Id,
                               StatusName= (ListGetReqByManagerVM.Status)r.StatusName,
                               RequestDate= r.RequestDate,
                               EmployeeId = u.Id,
                               EmpployeeName = u.FirstName+u.LastName
                           }).ToList();
            if (getData.Count == 0)
            {
                return null;
            }
            return getData.ToList();
        }
    }
}

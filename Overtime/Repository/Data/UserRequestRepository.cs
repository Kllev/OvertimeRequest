using Microsoft.EntityFrameworkCore;
using Overtime.Context;
using Overtime.Models;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Repository.Data
{
    public class UserRequestRepository : GeneralRepository<MyContext, UserRequest, int>
    {
        MyContext myContext;
        private readonly DbSet<RequestVM> request;

        public UserRequestRepository(MyContext myContext) :base(myContext)
        {
            this.myContext = myContext;
            this.request = myContext.Set<RequestVM>();
        }
        public int InsertUserReq(RequestVM requestVM)
        {
            Request request = new Request();
            myContext.Requests.Add(request);
            myContext.SaveChanges();

            foreach(var item in requestVM.userRequests)
            {
                var userRequest = new UserRequest()
                {
                    UserId = item.UserId,
                    RequestId = request.Id,
                    JobTask = item.JobTask,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Description = item.Description
                };
                myContext.UserRequests.Add(userRequest);
            }
            request.RequestDate = DateTime.Today;
            request.StatusName = (Request.Status)requestVM.StatusName;
            request.ApproverName = requestVM.ApproverName;
            request.SalaryOvertime = HitungSalary(requestVM.Time, requestVM.Salary);

            return myContext.SaveChanges();
        }
        public double HitungSalary(int time, int salary)
        {
            double salaryOT = 0;
            if (time == 1)
            {
                salaryOT += time * 1.5d * (1 / 173) * salary;
            }
            else if (time >= 1) 
            {
                salaryOT += time * 1.5d * (1 / 173) * salary;
                salaryOT += (time-1) * 2 * (1 / 173) * salary;
            }
            salaryOT = Math.Round(salaryOT, 2);
            return salaryOT;
        }
    }
}

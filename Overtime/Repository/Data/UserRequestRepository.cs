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
        private readonly DbSet<UserRequest> userRequests;
        private readonly DbSet<Request> requests;

        public UserRequestRepository(MyContext myContext) :base(myContext)
        {
            this.myContext = myContext;
            this.userRequests = myContext.Set<UserRequest>();
            this.requests = myContext.Set<Request>();
        }
        public int InsertUserReq(RequestVM requestVM)
        {
            Request request = new Request();
            request.RequestDate = DateTime.Today;
            request.StatusName = (Request.Status)requestVM.StatusName;
            request.ApproverName = requestVM.ApproverName;
            request.SalaryOvertime = HitungSalary(requestVM.Time, requestVM.Salary);
            myContext.Requests.Add(request);
            myContext.SaveChanges();

            foreach(var item in requestVM.userRequests)
            {
                var userRequest = new UserRequest();
                userRequest.UserId = item.UserId;
                userRequest.RequestId = request.Id;
                userRequest.JobTask = item.JobTask;
                userRequest.StartTime = item.StartTime;
                userRequest.EndTime = item.EndTime;
                userRequest.Date = item.Date;
                userRequest.Description = item.Description;
                myContext.UserRequests.Add(userRequest);
            }
            return myContext.SaveChanges();
        }
        public double HitungSalary(double time, double salary)
        {
            double salaryOT = 0;
            double ket = 0.00578034;
            if (time == 1)
            {
                salaryOT += 1 * 1.5 * ket * salary;
            }
            else if (time >= 1) 
            {
                salaryOT += 1 * 1.5 * ket * salary;
                salaryOT += (time-1) * 2 * ket * salary;
            }
            salaryOT = Math.Round(salaryOT, 2);
            return salaryOT;
        }
        public IEnumerable<UserReqVM> GetUserReqByReqId(int id)
        {
            var getData = (from  ur in myContext.UserRequests
                           join r in myContext.Requests on ur.RequestId equals r.Id
                           where ur.RequestId==id
                           select new UserReqVM
                           {
                               UserId=ur.UserId,
                               JobTask=ur.JobTask,
                               Description=ur.Description,
                               StartTime=ur.StartTime,
                               EndTime=ur.EndTime,
                               Date=ur.Date,
                               Time=ur.EndTime-ur.StartTime
                           }).ToList();
            if (getData.Count == 0)
            {
                return null;
            }
            return getData.ToList();
        }
    }
    
}

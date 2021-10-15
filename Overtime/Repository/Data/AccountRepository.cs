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
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        private readonly DbSet<Account> dbSet;

        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            this.dbSet = myContext.Set<Account>();
        }
        public IEnumerable<LoginVM> GetLoginVMs()
        {
            var getLoginVMs = (from u in myContext.Users
                               join a in myContext.Accounts on
                               u.Id equals a.Id
                               select new LoginVM
                               {
                                   Id = u.Id,
                                   Email = u.Email,
                                   Password = a.Password
                               }).ToList();
            if (getLoginVMs.Count == 0)
            {
                return null;
            }
            return getLoginVMs.ToList();
        }
        public string[] Roles(string email)
        {
            var all = (from p in myContext.Users
                       join a in myContext.Accounts on p.Id equals a.Id
                       join b in myContext.AccountRoles on a.Id equals b.AccountId
                       join c in myContext.Roles on b.RoleId equals c.Id
                       where p.Email == email
                       select new Role
                       {
                           Name = c.Name
                       }).ToList();
            string[] roles = new string[all.Count];
            for (int i = 0; i < all.Count; i++)
            {
                roles[i] = all[i].Name;
            }
            return roles;
        }

        public IEnumerable<ManagerVM> GetManagerName()
        {
            var getname = (from p in myContext.Users
                           join a in myContext.Accounts on p.Id equals a.Id
                           join b in myContext.AccountRoles on a.Id equals b.AccountId
                           where b.RoleId == 2 && p.Id == b.AccountId
                           select new ManagerVM
                           {
                               Id = p.Id,
                               fullName = p.FirstName + " " + p.LastName 
                           }).ToList();
            return getname;
        }

        public IEnumerable<ManagerVM> GetManagerNamePriority(string id)
        {
            var getname = (from p in myContext.Users
                           join a in myContext.Accounts on p.Id equals a.Id
                           join b in myContext.AccountRoles on a.Id equals b.AccountId
                           where p.Id == b.AccountId
                           select new ManagerVM
                           {
                               Id = p.Id,
                               fullName = p.FirstName + " " + p.LastName
                           }).ToList();
            return getname;
        }

        public LoginVM Login(LoginVM login)
        {
            if (myContext.Users.Where(u => u.Email == login.Email).Count() <= 0)
            {
                return null;
            }
            return (from u in myContext.Users
                    join a in myContext.Accounts
                    on u.Id equals a.Id
                    select new LoginVM
                    {
                        Email = u.Email,
                        Password = a.Password,
                    }
         ).Where(user => user.Email == login.Email).First();
        }
        public string GetId(string email)
        {
            var checkEmail = myContext.Users.Where(p => p.Email == email).FirstOrDefault();
            return checkEmail.Id;
        }
        public string GetName(string email)
        {
            var checkName = myContext.Users.Where(p => p.Email == email).FirstOrDefault();
            return checkName.FirstName;
        }
        public int GetSalary(string email)
        {
            var checkName = myContext.Users.Where(p => p.Email == email).FirstOrDefault();
            return checkName.Salary;
        }
        public string GetManagerId(string email)
        {
            var checkName = myContext.Users.Where(p => p.Email == email).FirstOrDefault();
            return checkName.ManagerID;
        }
        public string GetManager(string email)
        {
            var getname = (from p in myContext.Users
                           join a in myContext.Accounts on p.Id equals a.Id
                           join b in myContext.AccountRoles on a.Id equals b.AccountId
                           where p.Email == email 
                           select new ManagerVM
                           {
                               fullName = p.FirstName + " " + p.LastName
                           }).ToList();
            string manager = getname[0].fullName;
            return manager;
        }
        public LoginVM FindByEmail(string email)
        {
            var data = myContext.Users.Where(u => u.Email == email);
            if (data.Count() > 0)
            {
                return (from u in myContext.Users
                        join a in myContext.Accounts on
                        u.Id equals a.Id
                        select new LoginVM
                        {
                            Id=u.Id,
                            Email = u.Email,
                            Password = a.Password
                        }).Where(u => u.Email == email).First();
            }

            return null;
        }
        public bool ResetPassword(string Id, string newPassword)
        {
            //reset password
            dbSet.Update(new Account()
            {
                Id = Id,
                Password = BCrypt.Net.BCrypt.HashPassword(newPassword, BCrypt.Net.BCrypt.GenerateSalt(12))
            });
            myContext.SaveChanges();

            return true;
        }


    }
}

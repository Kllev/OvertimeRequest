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
    public class UserRepository : GeneralRepository<MyContext, User, string>
    {
        MyContext myContext;
        private readonly DbSet<RegisterVM> registers;
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            registers = myContext.Set<RegisterVM>();
        }
        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
            
        private static bool ValidatePassword(string password, string correct)
        {
            return BCrypt.Net.BCrypt.Verify(password, correct);
        }

        public int Register(RegisterVM register)
        {
            var checkEmail = myContext.Users.FirstOrDefault(p => p.Email == register.Email);
            var checkPhone = myContext.Users.FirstOrDefault(p => p.PhoneNumber == register.Phone);
            var checkUser = myContext.Users.FirstOrDefault(p => p.Id == register.userID);
            var insert = 0;
            //var result = 0;
            if (checkEmail == null && checkPhone == null && checkUser == null)
            {
                User user = new User
                {
                    Id = register.userID,
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    PhoneNumber = register.Phone,
                    GenderName = (User.Gender)register.gender,
                    Salary = register.Salary,
                    Email = register.Email,
                    DivisionId = register.DivisionID,
                    ManagerID = register.ManagerID 
                };
                myContext.Add(user);
                insert = myContext.SaveChanges();

                Account account = new Account
                {
                    Id = user.Id,
                    Password = HashPassword(register.Password)
                };
                myContext.Add(account);
                insert = myContext.SaveChanges();

                AccountRole accountrole = new AccountRole
                {
                    AccountId = user.Id,
                    RoleId = 1
                };
                myContext.Add(accountrole);
                insert = myContext.SaveChanges();
                return insert;
            }
            else if (checkEmail != null)
            {
                return 100;
            }
            else if (checkUser != null)
            {
                return 200;
            }
            else if (checkPhone != null)
            {
                return 300;
            }
            return insert;
        }

        public RegisterVM GetById(string id)
        {
            var all = (from p in myContext.Users
                       join a in myContext.Accounts on p.Id equals a.Id
                       select new RegisterVM
                       {
                           userID = p.Id,
                           FirstName = p.FirstName,
                           LastName = p.LastName,
                           Phone = p.PhoneNumber,
                           Salary = p.Salary,
                           Email = p.Email,
                           Password = a.Password,
                       });
            return all.FirstOrDefault(p => p.userID == id);
        }
    }
}

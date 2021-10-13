using Microsoft.EntityFrameworkCore;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccountRole>()
                .HasKey(ar => new { ar.AccountId, ar.RoleId });
            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Account)
                .WithMany(a => a.AccountRoles)
                .HasForeignKey(ar => ar.AccountId);
            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Role)
                .WithMany(r => r.AccountRoles)
                .HasForeignKey(ar => ar.RoleId);
            modelBuilder.Entity<Division>()
                .HasOne(d => d.Department)
                .WithMany(dp => dp.Divisions);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Division)
                .WithMany(d => d.Users);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<Account>(a => a.Id);
            modelBuilder.Entity<UserRequest>()
                .HasKey(ur => new { ur.UserId, ur.RequestId });
            modelBuilder.Entity<UserRequest>()
                .HasOne(u => u.User)
                .WithMany(ur => ur.UserRequests)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRequest>()
                .HasOne(r => r.Request)
                .WithMany(ur => ur.UserRequests)
                .HasForeignKey(ur => ur.RequestId);
            modelBuilder.Entity<Request>()
                .Property(r => r.SalaryOvertime)
                .HasColumnType("decimal(18,2)");
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}

using EntityLayer.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,int> 
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<DayOff> DayOffs { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<WorkHour> WorkHours { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AppUserAndWorkShift>().HasKey(c => new { c.WorkShiftID, c.AppUserID });
            modelBuilder.Entity<DepartmentAndWorkShift>().HasKey(c => new { c.WorkShiftID, c.DepartmentID });


            base.OnModelCreating(modelBuilder); //
            

        }
    }
}
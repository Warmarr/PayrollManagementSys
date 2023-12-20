using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PayrollManagementSys.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PayrollManagementSys.Data.Context
{
    public class AppDbContext :DbContext    
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<DayOff> DayOffs { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<PaymentInfo> PaymentInfos { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

           
        }
    }
}

using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class CompanyDbContext : IdentityDbContext<ApplicationUser>
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) 
        { 
        
        
        
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   optionsBuilder.UseSqlServer("server=DESKTOP-CPOFDU6\\MSSQLSERVER01; database=CompanyDb; trusted_connections=true;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //global filtering
          // modelBuilder.Entity<BaseEntity>().HasQueryFilter(x => !x.IsDeleted);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<EmployeeViewModel> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}

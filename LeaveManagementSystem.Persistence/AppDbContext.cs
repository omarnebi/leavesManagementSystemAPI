using LeaveManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "Alice Brown", Department = "IT", JoiningDate = new DateTime(2020, 1, 10) },
                new Employee { Id = 2, FullName = "Bob Green", Department = "HR", JoiningDate = new DateTime(2021, 3, 15) }
            );
        }
    }
}

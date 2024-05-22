using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.EntityFrameworkCore;

namespace GarageManagement.Infrastructure.Data
{
    public class DataContext : DbContext
	{
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RoleDetails> Roles { get; set; }
        public DbSet<DepartmentDetails> Departments { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Garagemanagement;User Id=sa;Password=123456aA@$;Persist Security Info=True");
            }
        }
    }
}


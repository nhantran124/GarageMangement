using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;
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
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetails> VehicleDetailsDb { get; set; }
        public DbSet<BusinessDetails> Business { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<CompanyInfo> CompanyInfoDb { get; set; }
        public DbSet<CustomerInfo> CustomerInfoDb { get; set; }
        public DbSet<SparePart> SparePartDb { get; set; }
        public DbSet<SparePartDetails> SparePartDetailsDb { get; set; }
        public DbSet<Inbound> InboundDb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Garagemanagement;User Id=sa;Password=123456aA@$;Persist Security Info=True");
            }
        }
    }
}


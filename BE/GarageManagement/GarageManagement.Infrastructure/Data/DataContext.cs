using System;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;
using GarageManagement.Domain.Entities.MaintenanceManagement;
using Microsoft.EntityFrameworkCore;

namespace GarageManagement.Infrastructure.Data
{
    public class DataContext : DbContext
	{
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RoleDetails> RoleDetailsDb { get; set; }
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
        public DbSet<AccessoryWarehouse> AccessoryWarehouseDb { get; set; }
        public DbSet<PermissionDetails> PermissionDetailsDb { get; set; }
        public DbSet<AccessDetails> AccessDetailsDb { get; set; }
        public DbSet<RepairBill> RepairBillDb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Garagemanagement;User Id=sa;Password=123456aA@$;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add configurations for RepairTicket
            modelBuilder.Entity<RepairBill>(entity =>
            {
                entity.Property(e => e.TaxGTGT).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(e => e.Staff) 
                    .WithMany()
                    .HasForeignKey(e => e.StaffId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.VehicleDetails)
                    .WithMany()
                    .HasForeignKey(e => e.VehicleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.CustomerInfo)
                    .WithMany()
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Add other configurations if necessary
        }
    }
}


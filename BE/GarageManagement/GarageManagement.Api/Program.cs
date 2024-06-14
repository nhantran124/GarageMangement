using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Infrastructure.Data;
using GarageManagement.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use the AddDIServices extension method to register services
builder.Services.AddDIServices();

// Add scoped services
builder.Services.AddScoped<IDepartmentApp, DepartmentApp>();
builder.Services.AddScoped<IStaffApp, StaffApp>();
builder.Services.AddScoped<ISupplierApp, SupplierApp>();
builder.Services.AddScoped<IFactoryApp, FactoryApp>();
builder.Services.AddScoped<IVehicleApp, VehicleApp>();
builder.Services.AddScoped<IVehicleDetailsApp, VehicleDetailsApp>();
builder.Services.AddScoped<IBusinessDetailsApp, BusinessDetailsApp>();
builder.Services.AddScoped<IInsuranceApp, InsuranceApp>();
builder.Services.AddScoped<ICompanyInfoApp, CompanyInfoApp>();
builder.Services.AddScoped<ICustomerInfoApp, CustomerInfoApp>();
builder.Services.AddScoped<ISparePartApp, SparePartApp>();
builder.Services.AddScoped<ISparePartDetailsApp, SparePartDetailsApp>();
builder.Services.AddScoped<IInboundApp, InboundApp>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

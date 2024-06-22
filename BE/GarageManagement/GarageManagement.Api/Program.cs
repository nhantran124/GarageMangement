using System.Text;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Infrastructure.Data;
using GarageManagement.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<DataContext>()
//    .AddDefaultTokenProviders();

builder.Services.AddDIServices();

// Configure JWT authentication
var jwtSettings = builder.Configuration.GetSection("JWT");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["ValidIssuer"],
        ValidAudience = jwtSettings["ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]))
    };
});

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
builder.Services.AddScoped<IAccessoryWarehouseApp, AccessoryWarehouseApp>();
builder.Services.AddScoped<IAccessDetailsApp, AccessDetailsApp>();
builder.Services.AddScoped<IRoleDetailsApp, RoleDetailsApp>();
builder.Services.AddScoped<IPermissionDetailsApp, PermissionDetailsApp>();
builder.Services.AddScoped<IRepairBillApp, RepairBillApp>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed((host) => true)
.AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
using Business.Implementacion.Base;
using Business.Interfaces.Base;
using Data.Implementacion.Base;
using Data.Implementacion.concesionario;
using Data.Interfaces.Base;
using Data.Interfaces.concesionario;
using Entitys.Context;
using Microsoft.EntityFrameworkCore;
using Utilities.Helper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(ABaseData<>), typeof(DataGeneric<>));
// Business genérico con DTOs
builder.Services.AddScoped(typeof(IBaseBusiness<,,>), typeof(BaseBusiness<,,>));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddScoped<IClientData, ClientData>();
builder.Services.AddScoped<IVehicleData, VehicleData>();
builder.Services.AddScoped<ISellerData, SellerData>();
builder.Services.AddScoped<ISaleData, SaleData>();
builder.Services.AddScoped<ISaleDetailsData, SaleDetailsData>();
builder.Services.AddScoped<ISupplierData, SupplierData>();
builder.Services.AddScoped<IVehicleSupplierData, VehicleSupplierData>();
// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

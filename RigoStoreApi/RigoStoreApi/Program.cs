using Domain.Interfaces.Repositories;
using Domain.Entities;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infraestructure.Common;
using Application.Interfaces;
using Application.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<RigoStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexionSql")));
builder.Services.AddScoped<IOrderRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IProductRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IOrderProductRepository<OrderProduct>, OrderProductRepository>();
builder.Services.AddScoped<IServiceOrder, ServiceOrder>();
builder.Services.AddScoped<IServiceProduct, ServiceProduct>();
builder.Services.AddScoped<IServiceOrderProduct, ServiceOrderProduct>();
builder.Services.AddScoped<ObjResponse>();
builder.Services.AddScoped<Common>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("devCorsPolicy", builder => {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("devCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

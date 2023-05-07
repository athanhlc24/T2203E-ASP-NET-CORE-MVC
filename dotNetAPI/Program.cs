﻿using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( policy=>
        {
           // policy.WithOrigins("https://localhost:7047/Product1"); những trang web cho phép dùng api này
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
           

        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("dotNetAPI");
builder.Services.AddDbContext<dotNetAPI.Entities.DataContext>(
    options => options.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
  
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
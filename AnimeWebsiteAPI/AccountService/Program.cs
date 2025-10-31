using System.Reflection;
using AccountService.Entities;
using AccountService.Helpers;
using AccountService.Interfaces;
using AccountService.Interfaces.RepositoryInterfaces;
using AccountService.Interfaces.ServiceInterfaces;
using AccountService.Repositories;
using AccountService.Services;
using Microsoft.Extensions.DependencyInjection;
using RepoDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registering AccountService dependencies
builder.Services.AddScoped<IDatabase, SqlServerDatabase>();

//Role Service
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

//Accout Service
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

//UserRole Service
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();

//Initialize RepoDb
GlobalConfiguration.Setup().UseSqlServer();

//Regiter HttpClient Factory
builder.Services.AddHttpClient("Account", client =>
{
    client.BaseAddress = new Uri("https://localhost:7155/");
    client.Timeout = TimeSpan.FromSeconds(60);
});

//Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

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

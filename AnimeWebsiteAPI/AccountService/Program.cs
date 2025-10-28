using AccountService.Entities;
using AccountService.Interfaces;
using AccountService.Interfaces.RepositoryInterfaces;
using AccountService.Interfaces.ServiceInterfaces;
using AccountService.Repositories;
using AccountService.Services;
using RepoDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registering AccountService dependencies
//Role Service
builder.Services.AddScoped<IDatabase, SqlServerDatabase>();
builder.Services.AddScoped<IRepository<Role>, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

//Accout Service
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IAccountService, UserProfileService>();

//Initialize RepoDb
GlobalConfiguration.Setup().UseSqlServer();

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

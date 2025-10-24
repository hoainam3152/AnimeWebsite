using AnimeService.Entities;
using AnimeService.Helpers;
using AnimeService.Interfaces;
using AnimeService.Interfaces.ServiceInterfaces;
using AnimeService.Repositories;
using AnimeService.Services;
using Microsoft.Extensions.DependencyInjection;
using RepoDb;

var builder = WebApplication.CreateBuilder(args);

GlobalConfiguration.Setup().UseSqlServer();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Services
builder.Services.AddScoped<IDatabase, SqlServerDatabase>();
builder.Services.AddScoped<IRepository<Anime>, AnimeRepository>();
builder.Services.AddScoped<IAnimeService, AnimeServiceImp>();

//Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
            policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
});

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

app.UseCors("AllowAngularApp");

app.MapControllers();

app.Run();

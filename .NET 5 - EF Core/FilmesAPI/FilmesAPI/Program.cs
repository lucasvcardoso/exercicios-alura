using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var cinemaConnection = builder.Configuration.GetConnectionString("CinemaConnection");

builder.Services.AddDbContext<FilmeContext>(opt => opt.UseMySql(cinemaConnection, new MySqlServerVersion(new Version(8, 0))));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appAssemblies = AppDomain.CurrentDomain.GetAssemblies();

builder.Services.AddAutoMapper(appAssemblies);

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

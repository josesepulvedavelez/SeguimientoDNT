using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SeguimientoDNT.Core.Interfaces;
using SeguimientoDNT.Infra;
using SeguimientoDNT.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de la cadena de conexi�n desde appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");
var configuration = builder.Configuration;

// Register DbContext and services
builder.Services.AddDbContext<SeguimientoDntConext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("cadena"));
});

builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

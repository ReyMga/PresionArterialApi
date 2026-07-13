using Microsoft.EntityFrameworkCore;
using PresionArterial.Api.Data;
using PresionArterial.Api.Interfaces;
using PresionArterial.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Controladores
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexión con SQL Server
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "No se encontró la cadena de conexión 'DefaultConnection'.");

// Registro de dependencias
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IMedicionService, MedicionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Por ahora desactivado porque estamos trabajando por HTTP.
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
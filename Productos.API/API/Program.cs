using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using DA;
using DA.Repositorios;
using Flujo;
using Microsoft.Extensions.Configuration;
using Reglas;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProducto, ProductoFlujo>();

builder.Services.AddScoped<IDA, ProductoDA>();
builder.Services.AddScoped<IRepositorioDapper, RepositorioDapper>();
builder.Services.AddScoped<IConfiguracion, Configuracion>();


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

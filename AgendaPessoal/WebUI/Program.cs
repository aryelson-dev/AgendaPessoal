using Aplicacao.Interfaces;
using Aplicacao.Servicos;
using Domain.Interfaces;
using Infraestrutura.Contextos;
using Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<AgendaPessoalContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("Default"));
});

// Add services to the container.
services.AddScoped<IContatoRepository, ContatoRepository>();
services.AddScoped<IContatoService, ContatoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

using Aplicacao.Interfaces;
using Aplicacao.Mapas.Perfis;
using Aplicacao.Servicos;
using Domain.Interfaces;
using Infraestrutura.Contextos;
using Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<AgendaContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("Default"));
});

// Add services to the container.
services.AddScoped<IContatoRepository, ContatoRepository>();
services.AddScoped<IEnderecoRepository, EnderecoRepository>();
services.AddScoped<IAgendaService, AgendaService>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

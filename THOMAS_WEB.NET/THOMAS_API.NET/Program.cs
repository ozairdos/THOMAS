using Microsoft.EntityFrameworkCore;
using THOMAS_API.NET.Repositories;
using THOMAS_API.NET.Repositories.Contexto;
using THOMAS_API.NET.Repositories.Entities;
using THOMAS_API.NET.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

Perfil.ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(Perfil.ConnectionStrings));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

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

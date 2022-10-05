using GestaoDeClientes.API.Model;
using GestaoDeClientes.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<dbContext>(x => x.UseSqlServer("Password=0123456789;Persist Security Info=True;User ID=sa;Initial Catalog=GestaoClientes;Data Source=LUCAS-PC"));
builder.Services.AddScoped<IGestaoRepository, GestaoRepository>();
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

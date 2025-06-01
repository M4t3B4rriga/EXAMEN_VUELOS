using Microsoft.EntityFrameworkCore;
using ViajecitosAPI.ec.edu.monster.controlador;
using ViajecitosAPI;
using ViajecitosAPI.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ViajecitosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ViajecitosConnection")));

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

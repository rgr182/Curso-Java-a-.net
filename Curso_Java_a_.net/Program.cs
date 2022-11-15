using Curso_Java_a_.net.DataAccess;
using Curso_Java_a_.net.Classes;
using Curso_Java_a_.net.DataAccess.DAL;
using Microsoft.EntityFrameworkCore;
using Curso_Java_a_.Classes;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependencias Inyeccion
builder.Services.AddScoped<IOperacionesMatematicas, OperacionesMatematicas>();
builder.Services.AddScoped<IConsulta, Consulta>();
// Add inyeccion de dependencias de la base de datos

var connectionString = builder.Configuration.GetConnectionString("EscuelaMysqlConnection");
builder.Services.AddDbContext<EscuelaContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();
/*
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EscuelaContext>();
    context.Database.Migrate();
}*/


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

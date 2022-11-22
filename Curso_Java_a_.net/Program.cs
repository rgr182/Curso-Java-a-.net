using Curso_Java_a_.net.DataAccess;
using Curso_Java_a_.net.Classes;
using Microsoft.EntityFrameworkCore;
using Curso_Java_a_.net.Context.DAL;
using Curso_Java_a_.net.Data.Access.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependencias Inyeccion
builder.Services.AddScoped<IOperacionesMatematicas, OperacionesMatematicas>();
builder.Services.AddScoped<IOperaciones, Operaciones>();
// Add inyeccion de dependencias de la base de datos

builder.Services.AddDbContext<EscuelaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EscuelaConnection"));
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

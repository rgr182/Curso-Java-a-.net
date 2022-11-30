using Microsoft.EntityFrameworkCore;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o =>
    o.AddDefaultPolicy(b =>
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string connectionStringtest = builder.Configuration.GetConnectionString("EscuelaMysqlConnection");
Environment.SetEnvironmentVariable("Connection", connectionStringtest);
builder.Services.AddDbContext<SchoolSystemTestContext>(options =>
{
    options.UseMySql(connectionStringtest, ServerVersion.AutoDetect(connectionStringtest));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

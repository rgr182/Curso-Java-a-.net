using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.Infraestructure;
using Curso_Java_a_.net.Utils.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o =>
    o.AddDefaultPolicy(b =>
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

AuthenticationConfig authenticationConfig = new AuthenticationConfig(builder);

builder.Services.AddSingleton<AuthUtils>(new AuthUtils(builder.Configuration));

string connectionStringtest = builder.Configuration.GetConnectionString("EscuelaConnection");

Environment.SetEnvironmentVariable("Connection", connectionStringtest);
builder.Services.AddDbContext<ClubLiaContext>(options =>
{
    options.UseMySql(connectionStringtest, ServerVersion.AutoDetect(connectionStringtest));
});

DependencyRegistry registry = new DependencyRegistry(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

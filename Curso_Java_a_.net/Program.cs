using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.Infraestructure;
using Curso_Java_a_.net.Utils.Security;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
// NLog: setup the path
var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
if (!Directory.Exists(logPath))
{
    Directory.CreateDirectory(logPath);
}
NLog.GlobalDiagnosticsContext.Set("LogDirectory", logPath);
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

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
    builder.Services.AddDbContext<SchoolSystemContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("EscuelaConnection"));
    });

    DependencyRegistry registry = new DependencyRegistry(builder);

    //services cors
    builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }));
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

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();
}
catch (Exception ex)
{
    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application exi
    NLog.LogManager.Shutdown();
}

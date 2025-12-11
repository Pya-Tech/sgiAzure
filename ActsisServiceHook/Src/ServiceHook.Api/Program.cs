using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using ServiceHook.Api.Middlewares;
using ServiceHook.Application.Configuration;
using ServiceHook.Application.Interfaces.Services;
using ServiceHook.Application.Services;
using ServiceHook.Domain.Interfaces.Providers;
using ServiceHook.Infrastructure.Providers;
using ServiceHook.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.File("Logs/info-.log", rollingInterval: RollingInterval.Day)
    .WriteTo.File("Logs/error-.log", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Error)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.Configure<BrokerMessageConfiguration>(builder.Configuration.GetSection("BrokerMessageConfiguration"));
builder.Services.AddScoped<BrokerMessageConfiguration>(sp =>
    sp.GetRequiredService<IOptions<BrokerMessageConfiguration>>().Value);

builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddSingleton<IBrokerMessageProvider, BrokerMessageProvider>();
builder.Services.AddScoped<IWorkItemMessagingService, RabbitMQWorkItemMessagingService>();

var app = builder.Build();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

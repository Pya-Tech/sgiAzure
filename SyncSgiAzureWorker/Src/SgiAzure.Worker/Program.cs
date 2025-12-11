using Serilog;
using SgiAzure.Worker.Extensions;
using SgiAzure.Worker.Workers;
using Log = Serilog.Log;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.File("Logs/worker-log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Services
    .AddApplicationSettings(builder.Configuration)
    .AddDatabaseContexts(builder.Configuration)
    .AddResilience()
    .AddMessaging(builder.Configuration)
    .AddRepositories()
    .AddFieldMappings()
    .AddApplicationServices()
    .AddMappers()
    .AddHandlers()
    .AddPipelines();

builder.Services.AddHostedService<CreateRequirementWorker>();
builder.Services.AddHostedService<CreateWorkItemWorker>();
builder.Services.AddHostedService<UpdateRequirementWorker>();
builder.Services.AddHostedService<UpdateWorkItemWorker>();

var host = builder.Build();
await host.Services.ValidateDatabaseConnectionsAsync();
await host.RunAsync();

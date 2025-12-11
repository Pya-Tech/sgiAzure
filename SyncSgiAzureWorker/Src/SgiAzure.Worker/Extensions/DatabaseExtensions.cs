using Microsoft.EntityFrameworkCore;
using SgiAzure.Domain.Exceptions;
using SgiAzure.Domain.Interfaces.Database;
using SgiAzure.Infrastructure.Databases.Sgi;
using SgiAzure.Infrastructure.Databases.SgiAzure;
using SgiAzure.Infrastructure.Transactions;

namespace SgiAzure.Worker.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabaseContexts(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextFactory<SgiAzureDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("MySqlConnection"),
                    new MySqlServerVersion(new Version(8, 0, 0))));

            services.AddDbContextFactory<SgiDbContext>(options =>
                options.UseOracle(
                    configuration.GetConnectionString("OracleConnection")));

            services.AddScoped<IDatabaseTransactionManager, TransactionManager>();

            return services;
        }

        /// <summary>
        /// Valida las conexiones a MySQL y Oracle antes de iniciar la aplicación.
        /// </summary>
        public static async Task ValidateDatabaseConnectionsAsync(this IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("DatabaseStartup");


            try
            {
                var mysqlFactory = serviceProvider.GetRequiredService<IDbContextFactory<SgiAzureDbContext>>();
                await using var mysqlContext = await mysqlFactory.CreateDbContextAsync();
                logger.LogInformation("Conectando con MySQL SgiAzure...");
                await mysqlContext.Database.OpenConnectionAsync();
                await mysqlContext.Database.CloseConnectionAsync();
                logger.LogInformation("Conexión Exitosa.");

            }
            catch (Exception ex)
            {

                logger.LogCritical(ex, "Error al conectar con MySQL");
                throw new SgiAzureException("Error al conectar con MySQL (SgiAzureDbContext).");
            }

            try
            {
                var oracleFactory = serviceProvider.GetRequiredService<IDbContextFactory<SgiDbContext>>();
                await using var oracleContext = await oracleFactory.CreateDbContextAsync();
                logger.LogInformation("Conectando con Oracle Sgi...");
                await oracleContext.Database.OpenConnectionAsync();
                await oracleContext.Database.CloseConnectionAsync();
                logger.LogInformation("Conexión Exitosa.");
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Error al conectar con Oracle");

                throw new SgiAzureException("Error al conectar con Oracle (SgiDbContext).");
            }
        }
    }
}

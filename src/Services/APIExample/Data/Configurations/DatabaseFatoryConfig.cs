using APIExample.Data.DataBaseFactory;
using APIExample.Data.DataBaseFactory.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIExample.Data.Configurations
{
    public static class DatabaseFatoryConfig
    {
        public static IServiceCollection AddConfigureDatabaseFactory<TContext>(
            this IServiceCollection services, 
            IConfiguration configuration
        ) where TContext : DbContext
        {
            
            // Recupera o tipo de banco de dados do appsettings.json
            var dbProvider = configuration["DatabaseProvider"];
            var connectionString = configuration.GetConnectionString(dbProvider);
            
            services.AddDbContext<GenericDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // Configura a injeção da fábrica correta
            switch (dbProvider.ToLower())
            {
                case "mysql":
                    services.AddScoped<IDatabaseFactory<TContext>, MySQLDatabaseFactory<TContext>>();
                    break;
                case "postgres":
                    services.AddScoped<IDatabaseFactory<TContext>, PostgresDatabaseFactory<TContext>>();
                    break;
                case "mssql":
                    services.AddScoped<IDatabaseFactory<TContext>, MSSQLDatabaseFactory<TContext>>();
                    break;
                case "oracle":
                    services.AddScoped<IDatabaseFactory<TContext>, OracleDatabaseFactory<TContext>>();
                    break;
                case "sqlite":
                    services.AddScoped<IDatabaseFactory<TContext>, SQLiteDatabaseFactory<TContext>>();
                    break;
                default:
                    throw new ArgumentException($"Provedor de banco de dados {dbProvider} não suportado.");
            }                           

            return services;

        }
    }
}

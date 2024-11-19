using Microsoft.EntityFrameworkCore;

namespace APIExample.Data.DataBaseFactory
{
    public class MySQLDatabaseFactory<TContext> : DatabaseFactory<TContext> where TContext : DbContext
    {
        public MySQLDatabaseFactory(IServiceCollection services) : base(services)
        {
            var connString = Configuration.GetConnectionString("MySQL");           
        }

        public override TContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString), sql => sql.MigrationsAssembly(MigrationAssembly));
            return (TContext)Activator.CreateInstance(typeof(TContext), optionsBuilder.Options)!;
        }
    }
}

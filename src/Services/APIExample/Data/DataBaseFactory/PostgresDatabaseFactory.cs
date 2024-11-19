using Microsoft.EntityFrameworkCore;

namespace APIExample.Data.DataBaseFactory
{
    public class PostgresDatabaseFactory<TContext> : DatabaseFactory<TContext> where TContext : DbContext
    {
        public PostgresDatabaseFactory(IServiceCollection services) : base(services)
        {
            var connString = Configuration.GetConnectionString("Postgres");           
        }       

        public override TContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseNpgsql(ConnectionString, sql => sql.MigrationsAssembly(MigrationAssembly));
            return (TContext)Activator.CreateInstance(typeof(TContext), optionsBuilder.Options)!;
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace APIExample.Data.DataBaseFactory
{
    public class SQLiteDatabaseFactory<TContext> : DatabaseFactory<TContext> where TContext : DbContext
    {
        public SQLiteDatabaseFactory(IServiceCollection services) : base(services)
        {
            ConnectionString = Configuration.GetConnectionString("sqlite");                     
        }

        public override TContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlite(ConnectionString, sql => sql.MigrationsAssembly(MigrationAssembly));
            return (TContext)Activator.CreateInstance(typeof(TContext), optionsBuilder.Options)!;
        }
    }
}

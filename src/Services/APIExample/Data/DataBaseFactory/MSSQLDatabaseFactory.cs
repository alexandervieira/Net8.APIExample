using Microsoft.EntityFrameworkCore;

namespace APIExample.Data.DataBaseFactory
{
    public class MSSQLDatabaseFactory<TContext> : DatabaseFactory<TContext> where TContext : DbContext
    {
        public MSSQLDatabaseFactory(IServiceCollection services) : base(services)
        {            
            ConnectionString = Configuration.GetConnectionString("MSSQL");
        }          

        public override TContext CreateDbContext()
        {            
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlServer(ConnectionString);            
            return (TContext)Activator.CreateInstance(typeof(TContext), optionsBuilder.Options)!;
        }       

    }
}

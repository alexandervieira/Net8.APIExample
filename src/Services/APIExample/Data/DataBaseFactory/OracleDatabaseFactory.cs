using Microsoft.EntityFrameworkCore;

namespace APIExample.Data.DataBaseFactory
{
    public class OracleDatabaseFactory<TContext> : DatabaseFactory<TContext> where TContext : DbContext
    {
        public OracleDatabaseFactory(IServiceCollection services) : base(services)
        {
            var connString = Configuration.GetConnectionString("Oracle");            
        }

        public override TContext CreateDbContext()
        {            
            return null;
        }
    }
}

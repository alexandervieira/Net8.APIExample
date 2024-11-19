using Microsoft.EntityFrameworkCore;

namespace APIExample.Data.DataBaseFactory.Interfaces
{
    public interface IDatabaseFactory<TContext> where TContext : DbContext
    {
        TContext CreateDbContext();

    }
}

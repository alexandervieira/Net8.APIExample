using APIExample.Data.Configurations;
using APIExample.Data.DataBaseFactory.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace APIExample.Data.DataBaseFactory
{
    public abstract class DatabaseFactory<TContext> : IDatabaseFactory<TContext> where TContext : DbContext
    {
        protected IServiceCollection Services;

        protected IConfiguration Configuration;
        
        protected string ConnectionString;

        protected static readonly string MigrationAssembly = typeof(ProviderConfiguration).GetTypeInfo().Assembly.GetName().Name;

        protected DatabaseFactory(IServiceCollection services)
        {
            Services = services;
            Configuration = Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        }

        public abstract TContext CreateDbContext();
       
    }
}

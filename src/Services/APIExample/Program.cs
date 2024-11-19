using APIExample.Data;
using APIExample.Data.Configurations;
using APIExample.Data.DataBaseFactory.Interfaces;
using APIExample.Data.Repositories;
using APIExample.Models;
using Microsoft.EntityFrameworkCore;

namespace APIExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton(builder.Services);

            builder.Services.AddConfigureDatabaseFactory<GenericDbContext>(builder.Configuration);

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/factory/products", async (IDatabaseFactory<GenericDbContext> factory) =>
            {
                var context = factory.CreateDbContext();                
                var products = await context.Products.ToListAsync();
                return Results.Ok(products);
            });

            app.MapGet("/products", async (IGenericRepository<Product> repo) =>
            {
                var products = await repo.GetAllAsync();
                return Results.Ok(products);
            });

            app.Run();
        }
    }
}

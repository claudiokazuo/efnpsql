using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Infrastructure.Contexts
{
    public class GenericContext<T> : DbContext where T : Entity
    {        
        public virtual DbSet<T> Entities { get; set; }

        public GenericContext()
        {        
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseNpgsql(configuration
                .GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder); 
        }
    }
}

using CurrencyConverter.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace CurrencyConverter.DAL
{
    public class ConverterDbContext : DbContext
    {
        public DbSet<TransactionDetails> TransactionDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connectionString = configBuilder.GetConnectionString("CurrencyConverterConnection");

            optionsBuilder.UseSqlServer(connectionString).LogTo(Console.WriteLine,LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransactionDetails>()
                .Property(p => p.Status).HasMaxLength(15);
        }
    }
}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using EntityFrameworkCore.Configuration;
using EntityFrameworkCore.Entities;
using EntityFrameworkCore.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCore.Data
{
    public class TechnosContext : DbContext
    {
        public TechnosContext(DbContextOptions<TechnosContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<Preco> Preco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //separei o configuration para deixa a classe CONTEXT  mais limpa
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new MarcaConfiguration());
            modelBuilder.ApplyConfiguration(new TipoProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PrecoConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //inicializando o context
            if (!optionsBuilder.IsConfigured)
            {
                string configPath = $"{Directory.GetCurrentDirectory()}\\appsettings.json";
                
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(configPath).Build();
                string connectionString = configuration.GetSection("ConnectionStrings").GetValue<string>("Default");
                optionsBuilder.UseSqlServer(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}

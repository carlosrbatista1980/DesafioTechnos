using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCore.Data
{
    public class TechnosContextFactory : IDesignTimeDbContextFactory<TechnosContext>
    {
        public TechnosContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string connectionString = configuration.GetSection("ConnectionStrings").GetValue<string>("Default");

            var builder = new DbContextOptionsBuilder<TechnosContext>();

            if (!string.IsNullOrEmpty(connectionString))
            {
                builder.UseSqlServer(connectionString);

                return new TechnosContext(builder.Options);
            }

            return new TechnosContext(new DbContextOptions<TechnosContext>());
        }
    }
}

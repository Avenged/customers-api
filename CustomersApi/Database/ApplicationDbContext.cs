using CustomersApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersApi.Database
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var section = _configuration.GetSection("ConnectionStrings");
            var connectionString = section["Default"];
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

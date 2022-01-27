using Microsoft.EntityFrameworkCore;
using SimplifaiInfo3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplifaiInfo3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> ProductTable { get; set; }

        public DbSet<Clients> ClientsTable { get; set; }


    }
}

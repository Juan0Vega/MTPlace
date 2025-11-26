using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }


    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Blahazon.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { set; get; }
        public DbSet<Payment> Payments { set; get; }
        public DbSet<Cart> Carts { set; get; }
        public DbSet<User> Users { set; get; }

        public DbSet<Order> Orders { set; get; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}

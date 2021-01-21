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

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>()
                .HasOne<Cart>(u => u.UserCart)
                .WithOne(c => c.CartUser)
                .HasForeignKey<Cart>(c => c.UserId);

            modelBuilder.Entity<Order>()
                .HasOne<Payment>(o => o.OrderPayment)
                .WithOne(p => p.PaymentOrder)
                .HasForeignKey<Payment>(p => p.OrderId);

            modelBuilder.Entity<Payment>()
                .HasOne<User>(p => p.PaymentUser)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId);

            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}

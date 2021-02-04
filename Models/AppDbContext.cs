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
        public DbSet<LineItem> LineItems { set; get; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
        //{
        //    modelBuilder.Entity<User>()
        //        .HasOne<Cart>(u => u.UserCart)
        //        .WithOne(c => c.CartUser)
        //        .HasForeignKey<Cart>(c => c.UserId);

        //    modelBuilder.Entity<User>()
        //        .HasMany<Order>(p => p.Orders)
        //        .WithOne(u => u.User)
        //        .HasForeignKey(p => p.UserId);

        //    modelBuilder.Entity<Order>()
        //        .HasOne<Payment>(o => o.OrderPayment)
        //        .WithOne(p => p.PaymentOrder)
        //        .HasForeignKey<Payment>(p => p.OrderId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //}

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}

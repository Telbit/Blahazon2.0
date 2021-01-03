using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Blahazon.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            for (int i = 0; i < 10; i++)
            {
                Products.Add(new Product
                {
                    Title = $"Title {i}",
                    Description = $"Description {i}",
                    ShortDescription = $"Short {i}",
                    Type = $"Type {i}",
                    InStock = true,
                    Price = 1000,
                    ImagePath = $"{AppDomain.CurrentDomain.BaseDirectory}images\\retard.png"
                });
                SaveChanges();
            }
        }

    }
}

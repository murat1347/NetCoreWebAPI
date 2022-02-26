using System;
using Microsoft.EntityFrameworkCore;

namespace Murat.API.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new() {Id = 1, Name = "Bilgisayar", CreatedDate = DateTime.Now, Price = 15000, Stock = 20},
                new() {Id = 2, Name = "Telefon", CreatedDate = DateTime.Now, Price = 18000, Stock = 20},
                new() {Id = 3, Name = "Klavye", CreatedDate = DateTime.Now, Price = 100, Stock = 20}
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
    }
}


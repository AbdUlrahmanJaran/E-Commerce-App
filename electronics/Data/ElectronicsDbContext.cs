using Electronics.Auth.Model;
using Electronics.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace electronics.Data
{
    public class ElectronicsDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        //orders stuff

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }






        public ElectronicsDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Laptops", Info = "A lot of Laptops"},
                new Category { Id = 2, Name = "Mobiles", Info = "A lot of Mobiles" }
                );

          modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, MakerName = "Asus", SubName = "XO2022", AboutProduct = "1tb SSD storage, 2x8 ddr4 ram 3000mhz, i5-10th, nvidia mx230", Price = 799.9, ReleaseDate = new DateTime(2022, 1, 22) },

                new Product { Id = 2, CategoryId = 1, MakerName = "Apple", SubName = "Mac 2019", AboutProduct = "500gb SSD storage, 8 ddr4 ram 3666mhz", Price = 999.9, ReleaseDate = new DateTime(2019, 6, 1) },

                new Product { Id = 3, CategoryId = 2, MakerName = "Apple", SubName = "Iphone 11", AboutProduct = "128gb storage", Price = 650.0, ReleaseDate = new DateTime(2019, 8, 4) },


            new Product { Id = 4, CategoryId = 2, MakerName = "Poco", SubName = "X3 NFC", AboutProduct = "128gb storage, 6gb ram", Price = 199.9, ReleaseDate = new DateTime(2021, 5, 5) }
                );
        }


        
    }
}

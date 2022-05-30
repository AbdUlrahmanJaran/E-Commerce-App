﻿using electronics.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace electronics.Data
{
    public class ElectronicsDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }


        public ElectronicsDbContext(DbContextOptions options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Laptops", Info = "Browse a wide selection of laptops from different Makers" },
                new Category { Id = 2, Name = "Mobile Phones", Info = "Browse a wide selection of Phones from different Makers" }

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

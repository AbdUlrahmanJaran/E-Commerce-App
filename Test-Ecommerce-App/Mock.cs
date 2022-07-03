using System;
using electronics.Data;
using Electronics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Electronics.Models;
using Xunit;

namespace Test_Ecommerce_App
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly ElectronicsDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new ElectronicsDbContext(
                new DbContextOptionsBuilder<ElectronicsDbContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<Product> CreateAndSaveTestProduct()
        {
            var product = new Product { MakerName = "Samsung", SubName = "S22 ultra", CategoryId = 1 };
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, product.Id);
            return product;
        }

        protected async Task<Category> CreateAndSaveTestCategory()
        {
            var category = new Category { Name = "Mobiles", Info = "Mobiles category" };
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, category.Id);
            return category;
        }
    }
}

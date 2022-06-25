using electronics.Data;
using Electronics.Interfaces;
using Electronics.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.Services
{
    public class ProductRepository : IProduct
    {
        private ElectronicsDbContext _context;

        public ProductRepository(ElectronicsDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(Product product)
        {
            Product newProduct = new Product
            {
                MakerName = product.MakerName,
                SubName = product.SubName,
                AboutProduct = product.AboutProduct,
                Price = product.Price
            };
            _context.Entry(newProduct).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new Product
                {
                    MakerName = p.MakerName,
                    SubName = p.SubName,
                    AboutProduct = p.AboutProduct,
                    Price = p.Price,
                    ReleaseDate = p.ReleaseDate,
                    Category = p.Category
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products
                .Select(p => new Product
                {
                    MakerName = p.MakerName,
                    SubName = p.SubName,
                    AboutProduct = p.AboutProduct,
                    Price = p.Price,
                    ReleaseDate = p.ReleaseDate,
                    Category = p.Category
                }).ToListAsync();
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}

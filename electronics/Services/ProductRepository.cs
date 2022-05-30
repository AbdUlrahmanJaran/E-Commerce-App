using electronics.Data;
using electronics.DTOs;
using electronics.Interfaces;
using electronics.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace electronics.Services
{
    public class ProductRepository : IProduct
    {
        private ElectronicsDbContext _context;

        public ProductRepository(ElectronicsDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(ProductDTO productDTO)
        {
            Product product = new Product { MakerName = productDTO.MakerName, SubName = productDTO.SubName,
                AboutProduct = productDTO.AboutProduct, Price = productDTO.Price };
            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            Product product  = await _context.Products.FindAsync(id);
            _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            return await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDTO
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

        public async Task<List<ProductDTO>> GetProducts()
        {
            return await _context.Products
                .Select(p => new ProductDTO
                {
                    MakerName = p.MakerName,
                    SubName = p.SubName,
                    AboutProduct = p.AboutProduct,
                    Price = p.Price,
                    ReleaseDate = p.ReleaseDate,
                    Category =  p.Category
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

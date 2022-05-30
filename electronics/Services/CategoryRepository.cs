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
    public class CategoryRepository : ICategory
    {
        private ElectronicsDbContext _context;

        public CategoryRepository(ElectronicsDbContext context)
        {
            _context = context;
        }
        public async Task<Category> AddCategory(CategoryDTO newCategory)
        {
            Category category = new Category { Name = newCategory.Name, Info = newCategory.Info};
            _context.Entry(category).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategory(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            _context.Entry(category).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryDTO>> GetCategories()
        {
            return await _context.Categories
                .Select(c => new CategoryDTO
                {
                    Name = c.Name,
                    Info = c.Info,
                    Products = c.Products
                }).ToListAsync();
        }

        public async Task<CategoryDTO> GetCategory(int id)
        {
            return await _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDTO
                {
                    Name = c.Name,
                    Info = c.Info,
                    Products = c.Products
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Category> UpdateCategory(int id, Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}

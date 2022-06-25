using electronics.Data;
using Electronics.Interfaces;
using Electronics.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.Services
{
    public class CategoryRepository : ICategory
    {
        private ElectronicsDbContext _context;

        public CategoryRepository(ElectronicsDbContext context)
        {
            _context = context;
        }



        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }


        public async Task<Category> AddCategory(Category newCategory)
        {
            Category category = new Category { Name = newCategory.Name, Info = newCategory.Info };
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

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories
                .Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name,
                    Info = c.Info,
                    Products = c.Products
                }).ToListAsync();
        }

        public async Task<Category> GetCategory(int? id)
        {
            return await _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new Category
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

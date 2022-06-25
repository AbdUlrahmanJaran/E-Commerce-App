using Electronics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics.Interfaces
{
    public interface ICategory
    {

        public Task<Category> GetCategory(int? id);

        public Task<List<Category>> GetCategories();

        public Task DeleteCategory(int id);

        public Task<Category> UpdateCategory(int id, Category category);

        public Task<Category> AddCategory(Category Category);


    }
}

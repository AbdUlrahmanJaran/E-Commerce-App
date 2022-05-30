using electronics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace electronics.Interfaces
{
    public interface ICategory
    {
        public Task<Category> GetCategory(int id);

        public Task<List<Category>> GetCategories();

        public Task DeleteCategory(int id);

        public Task UpdateCategory(int id);

        public Task<Category> AddCategory(Category category);


    }
}

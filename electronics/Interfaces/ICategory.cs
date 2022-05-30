using electronics.DTOs;
using electronics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace electronics.Interfaces
{
    public interface ICategory
    {
        public Task<CategoryDTO> GetCategory(int id);

        public Task<List<CategoryDTO>> GetCategories();

        public Task DeleteCategory(int id);

        public Task<Category> UpdateCategory(int id, Category category);

        public Task<Category> AddCategory(CategoryDTO categoryDTO);


    }
}

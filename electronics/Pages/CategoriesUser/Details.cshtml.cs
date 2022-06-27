using Electronics.Interfaces;
using Electronics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics.Pages.CategoriesUser
{
    public class DetailsModel : PageModel
    {
        private ICategory categoryService;
        public Category category { get; set; }
        public List<Product> Products { get; set; }

        public DetailsModel(ICategory service)
        {
            categoryService = service;
        }

        public async Task OnGet(int id)
        {
            category = await categoryService.GetCategory(id);
            if (category != null)
                Products = category.Products;
        }

    }
}

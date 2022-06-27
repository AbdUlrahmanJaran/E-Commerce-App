using Electronics.Controllers;
using Electronics.Interfaces;
using Electronics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics.Pages.CategoriesUser
{
    public class IndexModel : PageModel
    {
        private ICategory categoryService;

        [BindProperty]
        public List<Category> Categories { get; set; }

        public IndexModel(ICategory service)
        {
            categoryService = service;
        }

        public async Task OnGet()
        {
            Categories = await categoryService.GetCategories();
        }
    }
}

using Electronics.Controllers;
using Electronics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private CategoriesController _controller;

        public List<Category> Categories { get; set; }

        public IndexModel(CategoriesController controller)
        {
            _controller = controller;
        }

        public async Task OnGet()
        {
           
        }
    }
}

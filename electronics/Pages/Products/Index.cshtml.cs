using Electronics.Interfaces;
using Electronics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics.Pages.Products
{
    public class IndexModel : PageModel
    {
        private IProduct ProductService;

        public Product Product { get; set; }

        public IndexModel(IProduct service)
        {
            ProductService = service;
        }

        public async Task OnGetAsync(int id)
        {
            Product = await ProductService.GetProduct(id);
        }
    }
}

using Electronics.Interfaces;
using Electronics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics.Pages.ProductsUser
{
    public class IndexModel : PageModel
    {
        private IProduct ProductService;

        public List<Product> Products { get; set; }

        public IndexModel(IProduct service)
        {
            ProductService = service;
            
        }

        public async Task OnGetAsync()
        {
            Products = await ProductService.GetProducts();
        }
    }
}

using Electronics.Data.Cart;
using Electronics.Interfaces;
using Electronics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Electronics.Pages.ProductsUser
{
    public class DetailsModel : PageModel
    {
        private IProduct ProductService;
        private ShoppingCart CartService;
        public Product product { get; set; }

        public DetailsModel(IProduct productService, ShoppingCart cart)
        {
            ProductService = productService;
            CartService = cart;
        }
        public async Task OnGetAsync(int id)
        {
            product = await ProductService.GetProduct(id);
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            Product product = await ProductService.GetProduct(id);
            CartService.AddItemToCart(product);
            return RedirectToPage("Details" , new { id = id });
        }
    }
}

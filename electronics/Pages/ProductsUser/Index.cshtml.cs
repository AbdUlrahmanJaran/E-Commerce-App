using Electronics.Data.Cart;
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
        private ShoppingCart CartService;

        public List<Product> Products { get; set; }

        public IndexModel(IProduct product, ShoppingCart cart)
        {
            ProductService = product;
            CartService = cart;
        }

        public async Task OnGetAsync()
        {
            Products = await ProductService.GetProducts();
        }

        public async Task<IActionResult> OnPostAsync(int productId)
        {
            Product product = await ProductService.GetProduct(productId);
            CartService.AddItemToCart(product);
            return RedirectToPage();
        }
    }
}

using Electronics.Data.Cart;
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
        private ShoppingCart CartService;
        private IProduct ProductService;
        public Category category { get; set; }
        public List<Product> Products { get; set; }

        public DetailsModel(ICategory service, ShoppingCart cart, IProduct product)
        {
            categoryService = service;
            CartService = cart;
            ProductService = product;
        }

        public async Task OnGetAsync(int id)
        {
            category = await categoryService.GetCategory(id);
            if (category != null)
                Products = category.Products;
        }
        public async Task<IActionResult> OnPostAsync(int productId)
        {
            Product product = await ProductService.GetProduct(productId);
            CartService.AddItemToCart(product);

            return Redirect("../ProductsUser");
        }

    }
}

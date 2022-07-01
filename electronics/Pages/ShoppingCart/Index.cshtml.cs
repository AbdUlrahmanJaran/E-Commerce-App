using Electronics.Data.Cart;
using Electronics.Data.ViewModels;
using Electronics.Interfaces;
using Electronics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics.Pages.Shopping_Cart
{
    public class IndexModel : PageModel
    {
        private ShoppingCart CartService;
        private IProduct ProductService;
        public List<ShoppingCartItem> CartItems { get; set; }
        public double ShoppingCartTotal { get; set; }
        
        public IndexModel(ShoppingCart cart , IProduct product)
        {
            CartService = cart;
            ProductService = product;
        }

        public async Task OnGetAsync()
        {
            CartItems = CartService.GetAllItems();
            ShoppingCartTotal = CartService.GetTotal();
        }
        public async Task<IActionResult> OnPostAsync(int productId)
        {
            Product product = await ProductService.GetProduct(productId);
            CartService.AddItemToCart(product);
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostRemove(int productId)
        {
            Product product = await ProductService.GetProduct(productId);
            CartService.RemoveItemFromCart(product);
            return RedirectToPage();
        }
    }
}

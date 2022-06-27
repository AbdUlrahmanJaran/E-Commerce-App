using Electronics.Data.Cart;
using Electronics.Data.ViewModels;
using Electronics.Interfaces;
using Electronics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics.Pages.ShoppingCart
{
    public class IndexModel : PageModel
    {
        private Data.Cart.ShoppingCart CartService;

        public List<ShoppingCartItem> CartItems { get; set; }
        public double ShoppingCartTotal { get; set; }
        IProduct Product { get; set; }
        public IndexModel(Data.Cart.ShoppingCart service)
        {
            CartService = service;
        }

        public async Task OnGet()
        {
            CartItems = await CartService.GetAllItems();
            ShoppingCartTotal = CartService.GetTotal();
        }
        public async Task OnPost(int id)
        {
            Product product = await Product.GetProduct(id);
            CartService.AddItemToCart(product);
        }
    }
}

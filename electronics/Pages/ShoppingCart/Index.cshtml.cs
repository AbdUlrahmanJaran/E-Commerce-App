using Electronics.Data.Cart;
using Electronics.Data.ViewModels;
using Electronics.Interfaces;
using Electronics.Models;
using Electronics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Electronics.Pages.Shopping_Cart
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingCart CartService;
        private readonly IProduct ProductService;
        private readonly IOrder OrderService;
        private readonly EmailRepository EmailService;

        public List<ShoppingCartItem> CartItems { get; set; }
        public double ShoppingCartTotal { get; set; }
        
        public IndexModel(ShoppingCart cart , IProduct product, IOrder order, EmailRepository email)
        {
            CartService = cart;
            ProductService = product;
            OrderService = order;
            EmailService = email;
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


        public async Task<IActionResult> OnPostCheckout()
        {
            var items = CartService.GetAllItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            await OrderService.StoreOrder(items, userId, userEmailAddress);
            await CartService.ClearShoppingCart();
            string message = "Order Summary : <br/> ";
            foreach (ShoppingCartItem shopping in items)
            {
                message += $"you bought a  {shopping.Product.SubName}  for a price   {shopping.Product.Price} <br/>";
            }
            await EmailService.SendEmail(message, "22029470@student.ltuc.com", "Order Summary");
            await EmailService.SendEmail(message, userEmailAddress, "Order Summary");
            await EmailService.SendEmail(message, userEmailAddress, "Order Summary");
            return RedirectToPage("CompleteOrder");
        }
    }
}

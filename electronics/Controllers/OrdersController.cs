using Electronics.Data.Cart;
using Electronics.Data.Static;
using Electronics.Data.ViewModels;
using Electronics.Interfaces;
using Electronics.Models;
using Electronics.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Electronics.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProduct _product;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrder _order;
        private readonly EmailRepository _email;

        public OrdersController(IProduct product, ShoppingCart shoppingCart, IOrder order, EmailRepository email)
        {
            _product = product;
            _shoppingCart = shoppingCart;
            _order = order;
            _email = email;
        }

        // THIS FUNCTION WILL BECOME: GET ALL ORDERS FROM ALL USERS TO ADMIN
        [Authorize(Roles ="Admin, Editor")]
        public async Task<IActionResult> Index()
        {
            var items = await _order.GetOrdersByIdAndRole("", "");


            return View(items);
        }

        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetAllItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            await _order.StoreOrder(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCart();
            string message = "Order Summary : <br/> ";
            foreach (ShoppingCartItem shopping in items)
            {
                message += $"you bought a  {shopping.Product.SubName}  for a price   {shopping.Product.Price} <br/>";
            }
            await _email.SendEmail(message, "22029470@student.ltuc.com", "Order Summary");
            await _email.SendEmail(message, userEmailAddress, "Order Summary");
            await _email.SendEmail(message, userEmailAddress, "Order Summary");
            return View();
        }
    }
}

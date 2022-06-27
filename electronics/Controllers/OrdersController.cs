using Electronics.Data.Cart;
using Electronics.Data.ViewModels;
using Electronics.Interfaces;
using Electronics.Models;
using Electronics.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Electronics.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProduct _product;
        private readonly ShoppingCart _shoppingCart;
        //private readonly IOrder _order;
        private readonly EmailRepository _email;

        public OrdersController(IProduct product, ShoppingCart shoppingCart, EmailRepository email)
        {
            _product = product;
            _shoppingCart = shoppingCart;
           // _order = order;
            _email = email;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetAllItems();

            _shoppingCart.ShoppingCartItems = items.Result;

            var respone = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetTotal()
            };

            return View(respone);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _product.GetProduct(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return Ok();
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _product.GetProduct(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return Ok();
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetAllItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            //await _order.StoreOrderAsync(items, userId, userEmailAddress);
            //await _shoppingCart.ClearShoppingCartAsync();
            string message = "Order Summary : <br/> ";
            foreach (ShoppingCartItem shopping in items.Result)
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

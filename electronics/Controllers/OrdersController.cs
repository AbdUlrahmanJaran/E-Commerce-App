using Electronics.Data.Cart;
using Electronics.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Electronics.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ProductsController _productsController;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(ProductsController productsController, ShoppingCart shoppingCart)
        {
            _productsController = productsController;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetAllItems();

            _shoppingCart.ShoppingCartItems = items;

            var respone = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetTotal()

            };

            return View(respone);
        }
    }
}

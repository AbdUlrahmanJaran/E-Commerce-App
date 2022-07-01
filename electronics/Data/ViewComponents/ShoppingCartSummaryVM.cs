using Electronics.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Electronics.Data.ViewComponents
{
    // You can either add the annotation [ViewComponent] or make the  class inherit from it

    public class ShoppingCartSummaryVM : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummaryVM(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        //This is a default function that we need to invoke the VM
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetAllItems();

            return View(items.Count);
        }
    }
}

using Electronics.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics.Data.ViewComponents
{
    // You can either add the annotation [ViewComponent] or make the  class inherit from it

    public class MiniCartViewComponent : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public MiniCartViewComponent(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        //This is a default function that we need to invoke the VM
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetAllItems();

            return View(items);
        }
    }
}

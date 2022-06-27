using electronics.Data;
using Electronics.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Electronics.Data.Cart
{
    public class ShoppingCart
    {
        public ElectronicsDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }

        public List<Product> ShoppingCartItems { get; set; }

        public ShoppingCart(ElectronicsDbContext context)
        {
            _context = context;
        }

        public void AddItemToCart(Product product)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            //if we don't have that item in the cart, create a new one
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    ProductAmount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }

            //if we have that item in the shopping cart
            else
            {
                shoppingCartItem.ProductAmount++;
            }

            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Product product)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.ProductAmount > 1)
                {
                    shoppingCartItem.ProductAmount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();
        }


        public List<ShoppingCartItem> GetAllItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Product).ToList());
        }

        public double GetTotal()
        {
            var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Product.Price * n.ProductAmount).Sum();

            return total;
        }

    }
}

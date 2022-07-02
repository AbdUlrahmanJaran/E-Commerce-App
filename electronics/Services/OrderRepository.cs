using electronics.Data;
using Electronics.Interfaces;
using Electronics.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.Services
{
    public class OrderRepository : IOrder
    {
        private readonly ElectronicsDbContext _context;
        public OrderRepository(ElectronicsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByIdAndRole(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(m => m.Product).ToListAsync();

            

            return orders;
        }

        public async Task StoreOrder(List<ShoppingCartItem> shoppingCartItems, string userId, string userEmail)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmail,
                
                

            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderItem = new OrderItem()
                {
                    ProductId = shoppingCartItem.Product.Id,
                    Price = shoppingCartItem.Product.Price,
                    Amount = shoppingCartItem.ProductAmount,
                    OrderId = order.Id
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}

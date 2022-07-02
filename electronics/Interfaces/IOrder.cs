using Electronics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics.Interfaces
{
    public interface IOrder
    {
        Task StoreOrder(List<ShoppingCartItem> items, string userId, string userEmail);
        Task<List<Order>> GetOrdersByIdAndRole(string userId, string userRole);
    }
}

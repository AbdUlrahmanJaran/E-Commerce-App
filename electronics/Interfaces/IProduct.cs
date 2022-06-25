using Electronics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electronics.Interfaces
{
    public interface IProduct
    {
        public Task<Product> GetProduct(int id);

        public Task<List<Product>> GetProducts();

        public Task DeleteProduct(int id);

        public Task<Product> UpdateProduct(int id, Product Product);

        public Task<Product> AddProduct(Product Product);
    }
}

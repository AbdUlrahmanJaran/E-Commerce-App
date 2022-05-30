using electronics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace electronics.Interfaces
{
    public interface IProduct
    {
        public Task<Product> GetProduct(int id);

        //Get all your products from all your categories
        public Task<List<Product>> GetProducts();

        public Task DeleteProduct(int id);

        public Task UpdateProduct(int id);

        public Task<Product> AddProduct(Product product);


        //  For Future:
        //  1- Get All products in a specific category
        //  2- Get All products from a specific Maker
    }
}

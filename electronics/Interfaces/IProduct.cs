using electronics.DTOs;
using electronics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace electronics.Interfaces
{
    public interface IProduct
    {
        public Task<ProductDTO> GetProduct(int id);

        //Get all your products from all your categories
        public Task<List<ProductDTO>> GetProducts();

        public Task DeleteProduct(int id);

        public Task<Product> UpdateProduct(int id, Product product);

        public Task<Product> AddProduct(ProductDTO productDTO);


        //  For Future:
        //  1- Get All products in a specific category
        //  2- Get All products from a specific Maker
    }
}

using Electronics.Models;
using Electronics.Services;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace Test_Ecommerce_App
{
    public class UnitTest1 : Mock
    {
        [Fact]
        public void TestGetProduct()
        {
            Product product = (Product)CreateAndSaveTestProduct().Result;
            product.MakerName = "Samsung";

            var service = new ProductRepository(_db);
            Product NewProduct = service.GetProduct(product.Id).Result;

            Assert.Equal(NewProduct.MakerName, product.MakerName);
        }

        [Fact]
        public void TestGetCategory()
        {
            Category category = (Category)CreateAndSaveTestCategory().Result;
            category.Name = "Mobiles";

            var service = new CategoryRepository(_db);
            Category Newcategory = service.GetCategory(category.Id).Result;

            Assert.Equal(category.Name, Newcategory.Name);
        }

        [Fact]
        public async void TestUpdateProduct()
        {
            Product product = (Product)CreateAndSaveTestProduct().Result;
            string OldName = product.MakerName;

            product.MakerName = "Apple";
            var service = new ProductRepository(_db);
            product = await service.UpdateProduct(product.Id, product);
            product = service.GetProduct(product.Id).Result;

            Assert.NotEqual(OldName, product.MakerName);
        }

        [Fact]
        public async void TestUpdateCategory()
        {
            Category category = (Category)CreateAndSaveTestCategory().Result;
            string OldCategoryName = category.Name;

            category.Name = "Mobiles Category";
            var service = new CategoryRepository(_db);
            category = await service.UpdateCategory(category.Id, category);
            category = service.GetCategory(category.Id).Result;

            Assert.NotEqual(OldCategoryName, category.Name);
        }

        [Fact]
        public async void DeleteProduct()
        {
            Product product = (Product)CreateAndSaveTestProduct().Result;
            int id = product.Id;

            var repository = new ProductRepository(_db);
            await repository.DeleteProduct(id);

            product = await repository.GetProduct(id);
            Assert.Null(product);
        }

        [Fact]
        public async void DeleteCategory()
        {
            Category category = (Category)CreateAndSaveTestCategory().Result;
            int id = category.Id;

            var repository = new CategoryRepository(_db);
            await repository.DeleteCategory(id);

            category = await repository.GetCategory(id);
            Assert.Null(category);
        }
    }
}

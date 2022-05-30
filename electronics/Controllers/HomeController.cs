using electronics.Data;
using electronics.DTOs;
using electronics.Models;
using electronics.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace electronics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Categories()
        {
            List<Category> categories = new List<Category>();

            categories.Add(new Category() { Name = "Laptops", Info = "A wide selection of carried computers" });
            categories.Add(new Category() { Name = "Mobiles", Info = "A wide selection of mobile devices" });
            categories.Add(new Category() { Name = "Accessories", Info = "From mousepad to professional PC cases" });
            categories.Add(new Category() { Name = "Cameras", Info = "Your journy to become a photographer starts here" });


            return View(categories);
        }

        public IActionResult Products()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product() { MakerName = "Apple", SubName = "Iphone12", Price = 699.9 });
            products.Add(new Product() { MakerName = "Dell", SubName = "Inspiron", Price = 450.0 });
            products.Add(new Product() { MakerName = "Lenovo", SubName = "XNY", Price = 450.0 });
            products.Add(new Product() { MakerName = "Poco", SubName = "X3 NFC", Price = 230.0 });
            products.Add(new Product() { MakerName = "Logitech", SubName = "g402", Price = 45.0 });
            products.Add(new Product() { MakerName = "Apple", SubName = "iMac", Price = 2019.0 });


            return View(products);
        }
    }
}

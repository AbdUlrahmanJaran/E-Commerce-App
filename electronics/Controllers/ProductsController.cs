using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronics.Models;
using electronics.Data;
using Microsoft.AspNetCore.Http;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs.Models;
using Electronics.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Electronics.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _product;

        IConfiguration Configuration;

        public ProductsController(IProduct product, IConfiguration config)
        {
            _product = product;
            Configuration = config;
        }


        // GET: Products
        [Authorize(Roles ="Admin, Editor")]
        public async Task<IActionResult> Index()
        {
            var listOfProducts = await _product.GetProducts();
            return View(listOfProducts);
        }

        // GET: Products/Details/5
        [Authorize(Roles = "Admin, Editor")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _product.GetProduct(id);
            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,MakerName,SubName,AboutProduct,ReleaseDate,Price")] Product product, IFormFile file)
        {
            // Blob Part

            BlobContainerClient container = new BlobContainerClient(Configuration.GetConnectionString("AzureBlob"), "images");
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();

            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
            };

            if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }

            product.URL = blob.Uri.ToString();


            stream.Close();




            // Creating part

            if (ModelState.IsValid)
            {
                await _product.AddProduct(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }





        // GET: Products/Edit/5
        [Authorize(Roles = "Admin, Editor")]
        public async Task<IActionResult> Edit(int id)
        {
            Product updateProduct = await _product.GetProduct(id);

            if (updateProduct == null)
            {
                return NotFound();
            }
            return View(updateProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Editor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,MakerName,SubName,AboutProduct,ReleaseDate,Price")] Product product, IFormFile file)
        {
            BlobContainerClient container = new BlobContainerClient(Configuration.GetConnectionString("AzureBlob"), "images");
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();

            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
            };

            if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }

            product.URL = blob.Uri.ToString();


            stream.Close();

            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _product.UpdateProduct(product.Id, product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [Authorize(Roles = "Admin")]
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _product.GetProduct(id);
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _product.DeleteProduct(id);
            return RedirectToAction("Index");
        }


    }
}

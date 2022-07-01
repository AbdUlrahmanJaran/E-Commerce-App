using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronics.Models;
using electronics.Data;
using Electronics.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace Electronics.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategory _category;

        IConfiguration Configuration;


        public CategoriesController(ICategory category, IConfiguration config)
        {
            _category = category;
            Configuration = config;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var listOfCategories = await _category.GetCategories();
            return View(listOfCategories);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _category.GetCategory(id);
               
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        
        // GET: Categories/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Info")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _category.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category category = await _category.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Info")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _category.UpdateCategory(id, category);
            //        await _category.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!CategoryExists(category.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(category);


            if (ModelState.IsValid)
            {
                await _category.UpdateCategory(category.Id, category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _category.GetCategory(id);
            return View(category);
        }


        //[Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _category.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}

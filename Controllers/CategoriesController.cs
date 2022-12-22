using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPTBook.Data;
using FPTBook.Models;
using FPTBook.ViewModels;

namespace FPTBook.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public IActionResult Index(string searchString)
        {
            var cats = from c in _context.Categories select c;
            //var book = _context.Books.ToList();
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            if (!String.IsNullOrEmpty(searchString))
            {
                cats = cats.Where(t => t.CategoryName!.Contains(searchString));
            }
            //return View(await _context.Categories.ToListAsync());
            return View(cats);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            var categoriesNav = await _context.Categories.ToListAsync();
            ViewBag.Categories = categoriesNav;
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // GET: Categories/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CateViewModel cateViewModel)
        {
            if (ModelState.IsValid)
            {
                Categories categories = new Categories
                {
                    CategoryName = cateViewModel.CategoryName,
                    CategoryDescription = cateViewModel.CategoryDescription,
                };
                _context.Categories.Add(categories);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cateViewModel);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories.FindAsync(id);
            var cateViewModel = new CateViewModel()
            {
                CategoryName = categories.CategoryName,
                CategoryDescription = categories.CategoryDescription,
            };
            if (categories == null)
            {
                return NotFound();
            }
            return View(cateViewModel);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CateViewModel cateViewModel)
        {
            //if (id != categories.CategoryId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                var categories = await _context.Categories.FindAsync(id);
                categories.CategoryName = cateViewModel.CategoryName;
                categories.CategoryDescription = cateViewModel.CategoryDescription;
                _context.Update(categories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cateViewModel);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            var categoriesNav = await _context.Categories.ToListAsync();
            ViewBag.Categories = categoriesNav;
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }
            var categories = await _context.Categories.FindAsync(id);
            if (categories != null)
            {
                _context.Categories.Remove(categories);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriesExists(int id)
        {
          return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}

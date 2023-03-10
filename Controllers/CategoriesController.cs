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
using Microsoft.AspNetCore.Authorization;

namespace FPTBook.Controllers
{
    [Authorize(Roles = "Administrator,Staff")]
    [Route("[Controller]/[Action]")]
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
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            if (!String.IsNullOrEmpty(searchString))
            {
                cats = cats.Where(t => t.CategoryName!.Contains(searchString));
            }
            return View(cats);
        }

        // GET: Categories/Details/id
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CateViewModel cateViewModel)
        {
            var categories2 = _context.Categories.ToList();
            ViewBag.Categories = categories2;
            cateViewModel.Status = "Pending...";
            if (ModelState.IsValid)
            {

                Categories categories = new Categories
                {
                    CategoryName = cateViewModel.CategoryName,
                    CategoryDescription = cateViewModel.CategoryDescription,
                    Status = cateViewModel.Status,
                };
                RequestCate requestCate1 = new RequestCate
                {
                    Name = cateViewModel.CategoryName,
                    Description = cateViewModel.CategoryDescription,
                    Status = cateViewModel.Status,
                };
                _context.Categories.Add(categories);
                _context.RequestCates.Add(requestCate1);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cateViewModel);
        }

        // GET: Categories/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            var categories1 = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories1;
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }
            var categories = await _context.Categories.FindAsync(id);
            var cateViewModel = new CateViewModel()
            {
                CategoryName = categories.CategoryName,
                CategoryDescription = categories.CategoryDescription,
                Status = categories.Status,
            };
            if (categories == null)
            {
                return NotFound();
            }
            return View(cateViewModel);
        }

        // POST: Categories/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CateViewModel cateViewModel)
        {
            var categories2 = _context.Categories.ToList();
            ViewBag.Categories = categories2;
            if (id != cateViewModel.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                var categories = await _context.Categories.FindAsync(id);
                categories.CategoryName = cateViewModel.CategoryName;
                categories.CategoryDescription = cateViewModel.CategoryDescription;
                categories.Status = cateViewModel.Status;

                var request = await _context.RequestCates.FindAsync(id);
                request.Name = cateViewModel.CategoryName;
                request.Description = cateViewModel.CategoryDescription;
                request.Status = cateViewModel.Status;

                _context.Update(categories);
                _context.Update(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cateViewModel);
        }

        // GET: Categories/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            var categoriesNav = await _context.Categories.ToListAsync();
            ViewBag.Categories = categoriesNav;
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // POST: Categories/Delete/id
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

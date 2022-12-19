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
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BooksController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        //Upload File
        private string UploadedFile1(BookViewModel model)
        {
            string uniFileName1 = null;
            if(model.Img1 != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniFileName1 = Guid.NewGuid().ToString() + "_" + model.Img1.FileName;
                string filePath = Path.Combine(uploadsFolder, uniFileName1);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Img1.CopyTo(fileStream);
                }
            }
            return uniFileName1;
        }

        private string UploadedFile2(BookViewModel model)
        {
            string uniFileName2 = null;
            if (model.Img2 != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniFileName2 = Guid.NewGuid().ToString() + "_" + model.Img2.FileName;
                string filePath = Path.Combine(uploadsFolder, uniFileName2);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Img2.CopyTo(fileStream);
                }
            }
            return uniFileName2;
        }
        private string UploadedFile3(BookViewModel model)
        {
            string uniFileName3 = null;
            if (model.Img3 != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniFileName3 = Guid.NewGuid().ToString() + "_" + model.Img3.FileName;
                string filePath = Path.Combine(uploadsFolder, uniFileName3);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Img3.CopyTo(fileStream);
                }
            }
            return uniFileName3;
        }
        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            //Categories categories1 =new Categories();
            ViewBag.Categories = categories;
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookViewModel model)
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            if (ModelState.IsValid)
            {
                string uniFileName1 = UploadedFile1(model);
                string uniFileName2 = UploadedFile2(model);
                string uniFileName3 = UploadedFile3(model);
                Book book = new Book
                {
                    Title = model.Title,
                    Price = model.Price,
                    Rate = model.Rate,
                    Img1 = uniFileName1,
                    Img2 = uniFileName2,
                    Img3 = uniFileName3,
                    Quality = model.Quality,
                    CategoryId = model.CategoryId,
                };
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,Price,Rate,Img1,Img2,Img3,Quality,CategoryId")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Books.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return _context.Books.Any(e => e.BookId == id);
        }
    }
}

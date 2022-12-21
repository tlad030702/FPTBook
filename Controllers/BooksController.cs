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
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FPTBook.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
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
            string path = Path.Combine(webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (model.Img1 != null)
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
            string path = Path.Combine(webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
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
            string path = Path.Combine(webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
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

       
        public IActionResult Index()
        {
            var book = _context.Books.ToList();
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            return View(book);
        }

        // GET: Books/Details/5
     
        public async Task<IActionResult> Details(int? id)
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;
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
            ViewBag.Categories = categories;
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel model)
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
                    Status = model.Status,
                };
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
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
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            var book = await _context.Books.FindAsync(id);
            var bookViewModel = new BookViewModel()
            {
                Id = book.BookId,
                Title = book.Title,
                Price = book.Price,
                Rate = book.Rate,
                ExistingImg1 = book.Img1,
                ExistingImg2 = book.Img2,
                ExistingImg3 = book.Img3,
                Quality = book.Quality,
                CategoryId = book.CategoryId,
                Status = book.Status,
            };
            if (book == null)
            {
                return NotFound();
            }
            return View(bookViewModel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookViewModel bookViewModel)
        //public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,Price,Rate,Img1,Img2,Img3,Quality,CategoryId")] Book book)
        {
            if (id != bookViewModel.Id)
            {
                return NotFound();
            }
            //if (id != book.BookId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    var categories = _context.Categories.ToList();
                    ViewBag.Categories = categories;
                    var book = await _context.Books.FindAsync(bookViewModel.Id);
                    book.Title = bookViewModel.Title;
                    book.Price = bookViewModel.Price;
                    book.Rate = bookViewModel.Rate;
                    if (bookViewModel.Img1 != null)
                    {
                        if (bookViewModel.ExistingImg1 != null)
                        {
                            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", bookViewModel.ExistingImg1);
                            System.IO.File.Delete(filePath);
                        }

                        book.Img1 = UploadedFile1(bookViewModel);
                    }
                    if (bookViewModel.Img2 != null)
                    {
                        if (bookViewModel.ExistingImg1 != null)
                        {
                            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", bookViewModel.ExistingImg2);
                            System.IO.File.Delete(filePath);
                        }

                        book.Img2 = UploadedFile2(bookViewModel);
                    }
                    if (bookViewModel.Img3 != null)
                    {
                        if (bookViewModel.ExistingImg1 != null)
                        {
                            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", bookViewModel.ExistingImg3);
                            System.IO.File.Delete(filePath);
                        }

                        book.Img3 = UploadedFile3(bookViewModel);
                    }
                    book.Quality = bookViewModel.Quality;
                    book.CategoryId = bookViewModel.CategoryId;
                    _context.Books.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(bookViewModel.Id))
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
            return View();
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
            var bookViewModel = new BookViewModel()
            {
                Id = book.BookId,
                Title = book.Title,
                Price = book.Price,
                Rate = book.Rate,
                ExistingImg1 = book.Img1,
                ExistingImg2 = book.Img2,
                ExistingImg3 = book.Img3,
                Quality = book.Quality,
                CategoryId = book.CategoryId,
                Status = book.Status,
            };
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
                return Problem("Entity set 'ApplicationDbContext.Books' is null.");
            }
            var book = await _context.Books.FindAsync(id);
            string deleteFileFromFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            var CurrentImage1 = Path.Combine(Directory.GetCurrentDirectory(), deleteFileFromFolder, book.Img1);
            var CurrentImage2 = Path.Combine(Directory.GetCurrentDirectory(), deleteFileFromFolder, book.Img2);
            var CurrentImage3 = Path.Combine(Directory.GetCurrentDirectory(), deleteFileFromFolder, book.Img3);
            _context.Books.Remove(book);
            if (System.IO.File.Exists(CurrentImage1))
            {
                System.IO.File.Delete(CurrentImage1);
            }
            if (System.IO.File.Exists(CurrentImage2))
            {
                System.IO.File.Delete(CurrentImage2);
            }
            if (System.IO.File.Exists(CurrentImage3))
            {
                System.IO.File.Delete(CurrentImage3);
            }
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

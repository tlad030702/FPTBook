using FPTBook.Data;
using FPTBook.Models;
using FPTBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FPTBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            
            var books = from b in _context.Books select b;
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }
            return View(await books.ToListAsync());
        }

        public async Task<IActionResult> IndexSearch(int category)
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;
            IQueryable<int> cateQuery = from m in _context.Categories
                                        orderby m.CategoryId
                                        select m.CategoryId;
            var books = from b in _context.Books select b;
            if(category != 0)
            {
                books = books.Where(s => s.CategoryId == category);
            }
            var bookCate = new BookByCate
            {
                selectListCate = new SelectList(await cateQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };
            return View(bookCate);
        }
        //public async Task<IActionResult> Category(int categoryId)
        //{
        //    var categories = await _context.Categories.ToListAsync();
        //    ViewBag.Categories = categories;
        //    var books = from book in _context.Books select book;
        //    books = books.Where(s => s.CategoryId == categoryId);
        //    return View(books);
        //}
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

        public async Task<IActionResult> Privacy()
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;
            return View();
        }
        public async Task<IActionResult> About()
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;
            return View();  
        }

        public async Task<IActionResult> Contact()
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
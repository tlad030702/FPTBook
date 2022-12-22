using FPTBook.Data;
using FPTBook.Models;
using FPTBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        public async Task<IActionResult> Index(string searchString,int? categoryId)
        {
            var books = from b in _context.Books select b;
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }
            if (categoryId != null)
            {
                books = books.Where(s => s.CategoryId == categoryId);
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
            var bookCate = new BookbyCate
            {
                selectListItems = new SelectList(await cateQuery.Distinct().ToListAsync()),
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

        //Actions for Shopping Cart
        private Book getDetailBook(int id)
        {
            var book = _context.Books.Find(id);
            return book;
        }
        public IActionResult addCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart == null)
            {
                var book = getDetailBook(id);
                List<Cart> listCart = new List<Cart>()
               {
                   new Cart
                   {
                       Book = book,
                       Quantity = 1
                   }
               };
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));

            }
            else
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                bool check = true;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Book.BookId == id)
                    {
                        dataCart[i].Quantity++;
                        check = false;
                    }
                }
                if (check)
                {
                    dataCart.Add(new Cart
                    {
                        Book = getDetailBook(id),
                        Quantity = 1
                    });
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));              
            }

            return RedirectToAction(nameof(Index));

        }
        public IActionResult h0ld0n(int id)
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart == null)
            {
                var book = getDetailBook(id);
                List<Cart> listCart = new List<Cart>()
               {
                   new Cart
                   {
                       Book = book,
                       Quantity = 1
                   }
               };
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));

            }
            else
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                bool check = true;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Book.BookId == id)
                    {
                        dataCart[i].Quantity++;
                        check = false;
                    }
                }
                if (check)
                {
                    dataCart.Add(new Cart
                    {
                        Book = getDetailBook(id),
                        Quantity = 1
                    });
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
            }

            return Redirect("/Home/ListCart");

        }

        public async Task<IActionResult> ListCart()
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                if (dataCart.Count > 0)
                {
                    ViewBag.carts = dataCart;
                    return View();
                }
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult deleteCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);

                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Book.BookId == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                return RedirectToAction(nameof(ListCart));
            }
            return RedirectToAction(nameof(Index));
        }

        //public IActionResult updateCart(int id, int quantity)
        //{
        //    var cart = HttpContext.Session.GetString("cart");
        //    if (cart != null)
        //    {
        //        List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
        //        if (quantity > 0)
        //        {
        //            for (int i = 0; i < dataCart.Count; i++)
        //            {
        //                if (dataCart[i].Book.BookId == id)
        //                {
        //                    dataCart[i].Quantity = quantity;
        //                }
        //            }
        //            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
        //        }
        //        var cart2 = HttpContext.Session.GetString("cart");
        //        return Ok(quantity);
        //    }
        //    return BadRequest();

        //}


    }
}
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FPTBook.ViewModels
{
    public class BookByCate
    {
        public List<Book> Books { get; set; }
        public SelectList selectListCate { get; set; }
        public int CateId { get; set; }
    }
}

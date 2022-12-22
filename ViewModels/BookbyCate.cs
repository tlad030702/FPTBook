using FPTBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FPTBook.ViewModels
{
    public class BookbyCate
    {
        public List<Book> Books { get; set; }
        public SelectList selectListCate { get; set; }
        public int CateId { get; set; }
    }
}

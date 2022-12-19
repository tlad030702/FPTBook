using FPTBook.Models;
using System.ComponentModel.DataAnnotations;

namespace FPTBook.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public IFormFile Img1 { get; set; }
        public IFormFile Img2 { get; set; }
        public IFormFile Img3 { get; set; }
        public int Quality { get; set; }
        public int CategoryId { get; set; }
    }
}

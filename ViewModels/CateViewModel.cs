using System.ComponentModel.DataAnnotations;

namespace FPTBook.ViewModels
{
    public class CateViewModel
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string? CategoryDescription { get; set; }
    }
}

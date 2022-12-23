using System.ComponentModel.DataAnnotations;

namespace FPTBook.ViewModels
{
    public class CateViewModel : EditCateViewModel
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string? CategoryDescription { get; set; }
        public string Status { get; set; }
    }
}

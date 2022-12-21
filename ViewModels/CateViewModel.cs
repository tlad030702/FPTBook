using System.ComponentModel.DataAnnotations;

namespace FPTBook.ViewModels
{
    public class CateViewModel
    {
        public string CategoryName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required]
        public string? CategoryDescription { get; set; }
    }
}

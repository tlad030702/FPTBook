using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required]
        public string? CategoryDescription { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}

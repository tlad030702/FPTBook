using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTBook.Models
{
    public class Categories
    {
        [Key]
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required]
        public string? CategoryDescription { get; set; }
    }
}
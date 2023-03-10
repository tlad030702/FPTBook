using System.Collections.Generic;
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
        public string? CategoryDescription { get; set; }
        [Required]
        public string Status { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
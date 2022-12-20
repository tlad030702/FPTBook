using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTBook.Models
{
    public class RequestBook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public string? Img1 { get; set; }
        public string? Img2 { get; set; }
        public string? Img3 { get; set; }
        public int Quality { get; set; }
        [Required]
        public string Status { get; set; }
        [Display(Name = "Category")]
        [Column("CategoryId")]
        public int CategoryId { get; set; }
    }
}

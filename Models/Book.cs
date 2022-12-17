using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [StringLength(225, MinimumLength = 7, ErrorMessage = "Max is 225 character and min is 7 character")]
        public string Title { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? Publish { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public Categories Categories { get; set; }
    }
}

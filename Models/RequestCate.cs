using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models
{
    public class RequestCate
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}

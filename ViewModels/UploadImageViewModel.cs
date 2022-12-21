using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FPTBook.ViewModels
{
    public class UploadImageViewModel
    {
        [Display(Name = "Img1")]
        public IFormFile? Img1 { get; set; }
        [Display(Name ="Img2")]
        public IFormFile? Img2 { get; set; }
        [Display(Name = "Img3")]
        public IFormFile? Img3 { get; set; }
    }
}

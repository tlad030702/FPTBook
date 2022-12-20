namespace FPTBook.ViewModels
{
    public class EditImageViewModel : UploadImageViewModel
    {
        public int Id { get; set; }
        public string? ExistingImg1 { get; set; }
        public string? ExistingImg2 { get; set; }
        public string? ExistingImg3 { get; set; }
    }
}

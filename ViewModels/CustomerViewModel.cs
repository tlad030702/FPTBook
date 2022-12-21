using System;
namespace FPTBook.ViewModels
{
	public class CustomerViewModel
	{
		public string FullName { get; set; }
		public string Address { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public bool EmailConfirmed = true;
        public string RoleId = "C";
    }
}


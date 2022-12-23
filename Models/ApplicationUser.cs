using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
namespace FPTBook.Models
{
	public class ApplicationUser : IdentityUser
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}


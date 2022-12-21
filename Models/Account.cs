using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
namespace FPTBook.Models
{
	public class Account : IdentityUser
	{
		public string FullName { get; set; }
		public string Address { get; set; }
	}
}


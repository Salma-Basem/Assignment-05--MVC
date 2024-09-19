using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email is Required")]
		[EmailAddress(ErrorMessage = "Invalid Format for email")]
		public string Email { get; set; }
		[Required(ErrorMessage = " password is required")]
		public string Password { get; set; }
		public bool RememberMe { get; set; }  
	}
}

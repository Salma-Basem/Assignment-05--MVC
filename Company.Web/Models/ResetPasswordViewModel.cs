using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = " password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[a-zA-Z\d])[A-Za-z\d]{6,}$", ErrorMessage = "password must be at least 6 characters long")]
        public string Password { get; set; }
        [Required(ErrorMessage = " Confirm Password is required")]
        [Compare(nameof(Password), ErrorMessage = "confirm password do  not match password ")]
        public string ConfirmPassword { get; set; }
   
        public string Email { get; set; }
        public string Token { get; set; }
    }
}

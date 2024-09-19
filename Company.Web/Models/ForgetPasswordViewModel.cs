using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Format for email")]
        public string Email { get; set; }
    }
}

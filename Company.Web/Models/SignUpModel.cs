using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage="First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid Format for email")]
        public string Email { get; set; }
        [Required(ErrorMessage =" password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[a-zA-Z\d])[A-Za-z\d]{6,}$",ErrorMessage ="password must be at least 6 characters long")]
        public string Password { get; set; }
        [Required(ErrorMessage = " Confirm Password is required")]
        [Compare(nameof(Password),ErrorMessage ="confirm password do  not match password ")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = " Required to agree")]

        public bool IsAgree { get; set; }

    }

}

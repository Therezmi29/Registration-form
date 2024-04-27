using System.ComponentModel.DataAnnotations;

namespace RegistrationForm.Models
{
    public class SignUpViewModell
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [MaxLength(300)]
        [EmailAddress]
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,20}$", ErrorMessage = "Password must contains alphabet and numbers!")]
        public string Password { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Repassword")]
        public string RePassword { get; set; }

    }
}

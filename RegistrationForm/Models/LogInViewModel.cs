using System.ComponentModel.DataAnnotations;

namespace RegistrationForm.Models
{
    public class LogInViewModel
    {
        [MaxLength(300)]
        [EmailAddress]
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}

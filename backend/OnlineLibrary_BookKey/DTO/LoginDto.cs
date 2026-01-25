using System.ComponentModel.DataAnnotations;

namespace RustProject.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Project_Management_Api.DTOs
{
    public class SignUpDto
    {

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool isManager { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Project_Management_Api.DTOs
{
    public class LoginDto
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

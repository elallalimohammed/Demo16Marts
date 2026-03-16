using System.ComponentModel.DataAnnotations;

namespace UsersWebApiMoq16_03_2026.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

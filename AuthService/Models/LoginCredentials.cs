using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class LoginCredentials
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public LoginCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}

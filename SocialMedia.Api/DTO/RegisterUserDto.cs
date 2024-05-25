using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Api.DTO
{
    public class RegisterUserDto
    {
        [Required]
        public  string Username { get; set; }
        [Required]
        public  string Password { get; set; }
    }
}


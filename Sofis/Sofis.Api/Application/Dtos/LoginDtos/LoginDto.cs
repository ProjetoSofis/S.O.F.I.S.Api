using System.ComponentModel.DataAnnotations;

namespace Sofis.Api.Application.Dtos.LoginDtos
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

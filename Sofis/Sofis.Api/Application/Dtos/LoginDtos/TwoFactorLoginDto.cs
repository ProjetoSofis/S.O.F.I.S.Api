using System.ComponentModel.DataAnnotations;

namespace Sofis.Api.Application.Dtos.LoginDtos
{
    public class TwoFactorLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O código 2FA deve ter 6 dígitos")]
        public string TwoFactorCode { get; set; }
    }
}

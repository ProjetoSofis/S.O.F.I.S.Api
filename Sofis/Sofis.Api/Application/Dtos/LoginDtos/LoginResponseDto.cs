namespace Sofis.Api.Application.Dtos.LoginDtos
{
    public class LoginResponseDto
    {
        public bool IsTwoFactorRequired { get; set; } = false;
        public string? AcessToken { get; set; }
    }
}

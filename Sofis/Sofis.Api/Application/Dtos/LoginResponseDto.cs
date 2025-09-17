namespace Sofis.Api.Application.Dtos
{
    public class LoginResponseDto
    {
        public String Token { get; set; }
        public String Username { get; set; }
        public string Email { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}

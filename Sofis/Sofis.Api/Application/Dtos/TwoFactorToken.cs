namespace Sofis.Api.Application.Dtos
{
    public class TwoFactorToken
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsUsed { get; set; }
    }
}

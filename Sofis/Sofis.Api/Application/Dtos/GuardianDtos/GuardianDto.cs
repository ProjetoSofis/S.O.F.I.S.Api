namespace Sofis.Api.Application.Dtos.GuardianDtos
{
    public class GuardianDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid FamilyId { get; set; }
    }
}

namespace Sofis.Api.Application.Dtos.FamilyDtos
{
    public class CreateFamilyDto
    {
        public string Name { get; set; } = string.Empty;
        public string Kinship { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}

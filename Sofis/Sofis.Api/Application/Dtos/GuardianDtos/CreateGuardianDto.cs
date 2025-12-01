namespace Sofis.Api.Application.Dtos.GuardianDtos
{
    public class CreateGuardianDto
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Kinship { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid ChildId { get; set; }
    }
}

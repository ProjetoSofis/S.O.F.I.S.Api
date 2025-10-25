namespace Sofis.Api.Application.Dtos.ChildDtos
{
    public class UpdateChildDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Responsible { get; set; }
    }
}

namespace Sofis.Api.Application.Dtos.ChildDtos
{
    public class UpdateChildDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Responsible { get; set; }
        public string? MomName { get; set; }
        public string? DadName { get; set; }
    }
}

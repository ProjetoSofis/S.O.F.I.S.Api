using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Dtos
{
    public class ChildDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateOnly? BirthDate { get; set; }
        public string Responsible { get; set; } = string.Empty;
        public string MomName { get; set; } = string.Empty;
        public string DadName { get; set; } = string.Empty;
        public List<Report> reports { get; set; } = new();
    }
}

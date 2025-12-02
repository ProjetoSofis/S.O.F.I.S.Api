using Sofis.Api.Application.Dtos.GuardianDtos;
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
        public string CodigoEol { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string UnidadeEscolar { get; set; } = string.Empty;
        public string AnoEscolar { get; set; } = string.Empty;
        public string MomName { get; set; } = string.Empty;
        public string DadName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public Guid FamilyId { get; set; }
        public List<Report> reports { get; set; } = new();
        public ICollection<GuardianDto> Guardians { get; set; }
    }
}

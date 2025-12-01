namespace Sofis.Api.Application.Dtos.ChildDtos
{
    public class UpdateChildDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Responsible { get; set; }
        public string? CodigoEol { get; set; }
        public string? Endereco { get; set; }
        public string? UnidadeEscolar { get; set; }
        public string? AnoEscolar { get; set; }
        public string? MomName { get; set; }
        public string? DadName { get; set; }
    }
}

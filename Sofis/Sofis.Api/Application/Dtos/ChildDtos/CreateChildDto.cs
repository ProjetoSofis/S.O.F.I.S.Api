namespace Sofis.Api.Application.Dtos.ChildDtos
{
    public class CreateChildDto
    {
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Responsible { get; set; } = string.Empty;


    }
}


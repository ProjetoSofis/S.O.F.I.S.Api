namespace Sofis.Api.Application.Dtos
{
    public class CreateChildDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Responsible { get; set; } = string.Empty;
    }
}

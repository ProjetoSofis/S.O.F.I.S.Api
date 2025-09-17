namespace Sofis.Api.Application.Dtos
{
    public class ChildDto
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string Responsible { get; set; } = string.Empty;
        public List<AnnotationDto> Annotations { get; set; } = new();
    }
}

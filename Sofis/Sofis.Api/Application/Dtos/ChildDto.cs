namespace Sofis.Api.Application.Dtos
{
    public class ChildDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string Responsible { get; set; } = string.Empty;
        public List<AnnotationDto> Annotations { get; set; } = new();
    }
}

namespace Sofis.Api.Application.Dtos
{
    public class UpdateChildDto
    {
        public Guid Id { get; set; } 
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Responsible { get; set; }
        public List<AnnotationDto>? Annotations { get; set; }
    }
}

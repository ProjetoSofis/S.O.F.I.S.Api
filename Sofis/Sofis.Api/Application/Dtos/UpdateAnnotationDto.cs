namespace Sofis.Api.Application.Dtos
{
    public class UpdateAnnotationDto
    {
        public Guid Id { get; set; } 

        public DateTime? Date { get; set; }

        public string? Note { get; set; }
    }
}

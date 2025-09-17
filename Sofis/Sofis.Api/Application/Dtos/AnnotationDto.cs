namespace Sofis.Api.Application.Dtos
{
    public class AnnotationDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}

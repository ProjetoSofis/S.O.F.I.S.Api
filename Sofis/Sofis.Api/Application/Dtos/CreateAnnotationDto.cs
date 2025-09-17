namespace Sofis.Api.Application.Dtos
{
    public class CreateAnnotationDto
    {
        public Guid EmployeeId { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}

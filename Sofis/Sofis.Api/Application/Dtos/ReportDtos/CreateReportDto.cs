namespace Sofis.Api.Application.Dtos.ReportDtos
{
    public class CreateReportDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ChildId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}

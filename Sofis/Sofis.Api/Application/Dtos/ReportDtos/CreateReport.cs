namespace Sofis.Api.Application.Dtos.ReportDtos
{
    public class CreateReport
    {
        public Guid EmployeeId { get; set; }
        public Guid ChildId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}

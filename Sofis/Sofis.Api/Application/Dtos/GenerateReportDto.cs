namespace Sofis.Api.Application.Dtos
{
    public class GenerateReportDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}

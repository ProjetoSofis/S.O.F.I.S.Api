namespace Sofis.Api.Application.Dtos.ReportDtos
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime PeriodoStart { get; set; }
        public DateTime PeriodoEnd { get; set; }
        //public List<RecordDto> Records { get; set; }
    }
}

namespace Sofis.Api.Application.Dtos
{
    public class UpdateReportDto
    {
        public Guid Id { get; set; }  

        public Guid? EmployeeId { get; set; }

        public DateTime? PeriodoStart { get; set; }

        public DateTime? PeriodoEnd { get; set; }

        public List<RecordDto>? Records { get; set; } 
    }
}

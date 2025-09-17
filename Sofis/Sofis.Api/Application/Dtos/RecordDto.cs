namespace Sofis.Api.Application.Dtos
{
    public class RecordDto
    {
        public Guid Id { get; set; }
        public Guid ChildId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
    }
}

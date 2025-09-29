namespace Sofis.Api.Application.Dtos
{
    public class UpdateRecordDto
    {
        public Guid Id { get; set; } 

        public Guid? ChildId { get; set; }

        public Guid? EmployeeId { get; set; }

        public DateTime? Date { get; set; }
    }
}

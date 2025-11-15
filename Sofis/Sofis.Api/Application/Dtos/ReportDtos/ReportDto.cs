using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Dtos.ReportDtos
{
    public class ReportDto
    {
        public Guid EmployeeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ChildId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

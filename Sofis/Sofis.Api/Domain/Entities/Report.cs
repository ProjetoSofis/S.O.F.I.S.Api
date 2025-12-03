namespace Sofis.Api.Domain.Entities
{
    public class Report : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Employee? Employee { get; set; }
        public Guid ChildId { get; set; }
        public Child? Child { get; set; }

        public Report() { }

        public Report(Guid employeeId, string title,string description, Guid childId)
        {
            Id = Guid.NewGuid();
            EmployeeId = employeeId;
            Title = title;
            ChildId = childId;
            CreatedAt = DateTime.UtcNow;
            Description = description;
        }
    }
}

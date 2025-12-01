namespace Sofis.Api.Domain.Entities
{
    public class Report : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Employee Employee { get; set; }
        public Guid ChildId { get; set; }
        public Child Child { get; set; }

        public Report() { }

        public Report(Guid employeeId, string description, Guid childId)
        {
            Id = Guid.NewGuid();
            EmployeeId = employeeId;
            ChildId = childId;
            CreatedAt = DateTime.UtcNow;
            Description = description;
        }
    }
}

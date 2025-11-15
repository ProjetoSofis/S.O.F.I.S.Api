namespace Sofis.Api.Domain.Entities
{
    public class Report : BaseEntity
    {
        public Guid EmployeeId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Employee Employee { get; private set; }
        public Guid ChildId { get; private set; }
        public Child Child { get; private set; }

        private Report() { }

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

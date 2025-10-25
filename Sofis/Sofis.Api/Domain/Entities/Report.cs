namespace Sofis.Api.Domain.Entities
{
    public class Report : BaseEntity
    {
        public Guid EmployeeId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Child Child { get; private set; }

        private Report() { }

        public Report(Guid employeeId, string description)
        {
            Id = Guid.NewGuid();
            EmployeeId = employeeId;
            CreatedAt = DateTime.UtcNow;
            Description = description;
        }
    }
}

namespace Sofis.Api.Domain.Entities
{
    public class Report
    {
        public Guid Id { get; private set; }
        public Guid EmployeeId { get; private set; }
        public DateTime Period { get; private set; }

        private readonly List<Registry> _registrys = new();
        private IReadOnlyCollection<Registry> registrys => _registrys.AsReadOnly();
        private Report() { }

        public Report(Guid employeeId, DateTime period)
        {
            Id = Guid.NewGuid();
            EmployeeId = employeeId;
            Period = period;
        }
        public void Addregistry(Registry registry)
        {
            _registrys.Add(registry);
        }
    }
}

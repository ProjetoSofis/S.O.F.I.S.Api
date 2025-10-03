namespace Sofis.Api.Domain.Entities
{
    public class Annotation
    {
        public Guid Id { get; private set; }
        public Guid EmployeeId { get; private set; }
        public DateTime Date { get; private set; }
        public string Note { get; private set; }

        public Annotation() { }

        public Annotation(Guid employeeId, DateTime date, string note)
        {
            Id = Guid.NewGuid();
            EmployeeId = employeeId;
            Date = date;
            Note = note;
        }
    }
}

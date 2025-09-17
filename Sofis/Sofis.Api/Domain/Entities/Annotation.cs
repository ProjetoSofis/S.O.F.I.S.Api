namespace Sofis.Api.Domain.Entities
{
    public class Annotation
    {
        public Guid Id { get; private set; }
        public Guid EmployeeId { get; private set; }
        public DateTime Date { get; private set; }
        public string Note { get; private set; }

        private Annotation() { }

        public Annotation(Guid id, Guid employeeId, DateTime date, string note)
        {
            Id = id;
            EmployeeId = employeeId;
            Date = date;
            Note = note;
        }
    }
}

namespace Sofis.Api.Domain.Entities
{
    public class Child
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Responsible { get; private set; }

        public readonly List<Annotation> _annotations = new();
        public IReadOnlyCollection<Annotation> Annotations => _annotations.AsReadOnly();

        private Child() { }

        public Child(string name, DateTime birthDate, string responsible)
        {
            Id = Guid.NewGuid();
            Name = name;
            BirthDate = birthDate;
            Responsible = responsible;
        }

        public void AddAnnotation(string text, Guid employeeId)
        {
            _annotations.Add(new Annotation(employeeId, text));
        }
    }
}

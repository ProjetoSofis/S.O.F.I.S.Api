using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Sofis.Api.Domain.Entities
{
    public class Child
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Responsible { get; set; }

        public readonly List<Annotation> _annotations = new();
        public IReadOnlyCollection<Annotation> Annotations => _annotations.AsReadOnly();

        public Child() { }

        public Child(string name, DateTime birthDate, string responsible)
        {
            Id = Guid.NewGuid();
            Name = name;
            BirthDate = birthDate;
            Responsible = responsible;
        }

        public void AddAnnotation(string text, DateTime date, Guid employeeId)
        {
            _annotations.Add(new Annotation(employeeId, date, text));
        }
    }
}

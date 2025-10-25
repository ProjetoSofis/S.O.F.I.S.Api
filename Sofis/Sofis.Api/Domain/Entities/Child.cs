using System.ComponentModel.DataAnnotations;

namespace Sofis.Api.Domain.Entities
{
    public class Child : BaseEntity
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Responsible { get; set; }

        public List<Family> FamilyMembers { get; private set; } = new();

        public readonly List<Report> _annotations = new();
        public IReadOnlyCollection<Report> Annotations => _annotations.AsReadOnly();

        public Child() { }

        public Child(string name, DateTime birthDate, string responsible)
        {
            Id = Guid.NewGuid();
            Name = name;
            BirthDate = birthDate;
            Responsible = responsible;
            CreatedAt = DateTime.UtcNow;
        }

        //public void AddAnnotation(string text, DateTime date, Guid employeeId)
        //{
        //    _annotations.Add(new Report(employeeId, date, text));
        //}

        public void AddFamilyMember(Family familyMember)
        {
            FamilyMembers.Add(familyMember);
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Sofis.Api.Domain.Entities
{
    public enum Status
    {
        Ativo,
        Inativo
    }
    public class Child : BaseEntity
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly BirthDate { get; set; }
        public string Responsible { get; set; }

        public string MomName { get; set; }
        public string DadName { get; set; }
        public Status Status { get; set; }
        public List<Family> FamilyMembers { get; private set; } = new();

        public readonly List<Report> _annotations = new();
        public IReadOnlyCollection<Report> Annotations => _annotations.AsReadOnly();

        public Child() { }

        public Child(string name, DateOnly birthDate, string responsible, string momName, string dadName, Status status)
        {
            Id = Guid.NewGuid();
            Name = name;
            BirthDate = birthDate;
            Responsible = responsible;
            MomName = momName;
            DadName = dadName;
            Status = status;
            CreatedAt = DateTime.UtcNow;
        }

        //public void AddAnnotation(string text, DateOnly date, Guid employeeId)
        //{
        //    _annotations.Add(new Report(employeeId, date, text));
        //}

        public void AddFamilyMember(Family familyMember)
        {
            FamilyMembers.Add(familyMember);
        }
    }
}

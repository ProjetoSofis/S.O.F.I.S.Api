namespace Sofis.Api.Domain.Entities
{
    public class Guardian : BaseEntity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Kinship { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Guid FamilyId { get; set; }
        public Family Family { get; set; }

    }
}

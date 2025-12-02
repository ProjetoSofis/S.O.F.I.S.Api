namespace Sofis.Api.Domain.Entities
{
    public class Guardian : BaseEntity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Kinship { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Child> Children { get; set; } = new List<Child>();

    }
}

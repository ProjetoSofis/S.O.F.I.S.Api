namespace Sofis.Api.Domain.Entities
{
    public class Family : BaseEntity
    {
        public string Name { get; set; }
        public string Kinship { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public List<Child> RelationedChildren { get; set; } = new();

        public Family() { }

        public Family(string name, string kinship, string phone, string cpf,string email, string address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Kinship = kinship;
            Phone = phone;
            Cpf = cpf;
            Email = email;
            Address = address;
            CreatedAt = DateTime.UtcNow;
        }
    }
}

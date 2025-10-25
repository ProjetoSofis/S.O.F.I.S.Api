namespace Sofis.Api.Domain.Entities
{
    public class Family : BaseEntity
    {
        public string Name { get; private set; }
        public string Kinship { get; private set; }
        public string Contact { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        public List<Child> RelationedChildren { get; private set; } = new();

        public Family() { }

        public Family(string name, string kinship, string contact, string email, string address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Kinship = kinship;
            Contact = contact;
            Email = email;
            Address = address;
            CreatedAt = DateTime.UtcNow;
        }
    }
}

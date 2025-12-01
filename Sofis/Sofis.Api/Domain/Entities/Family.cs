namespace Sofis.Api.Domain.Entities
{
    public class Family : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }


       public ICollection<Child> RelationedChildren { get; set; } = new List<Child>();
       public ICollection<Guardian> Guardians { get; set; } = new List<Guardian>();

        public Family() { }

        public Family(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }
    }
}

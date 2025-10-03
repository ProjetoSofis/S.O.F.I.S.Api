namespace Sofis.Api.Domain.Entities
{
    public class Registry
    {
        public Guid Id { get; private set; }
        public List<Child> Children { get; private set; }
        public Employee Author { get; private set; }
        public DateTime Date { get; private set; }

        public Registry() { }

        public Registry(List<Child> children, Employee author)
        {
            Id = Guid.NewGuid();
            Children = children;
            Author = author;
            Date = DateTime.UtcNow;
        }
    }
}

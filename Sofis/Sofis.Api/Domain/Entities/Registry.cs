namespace Sofis.Api.Domain.Entities
{
    public class Registry
    {
        public string Id { get; private set; }
        public List<Child> Children { get; private set; }
        public Employee Author { get; private set; }
        public DateTime Date { get; private set; }

        private Registry() { }

        public Registry(List<Child> children, Employee author)
        {
            Id = Guid.NewGuid().ToString();
            Children = children;
            Author = author;
            Date = DateTime.UtcNow;
        }
    }
}

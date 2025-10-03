namespace Sofis.Api.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Employee() { }

        public Employee(string name, string email, string phone, string passwordHash)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
        }
    }
}

namespace Sofis.Api.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string PasswordHash { get; private set; }
        public string Role { get; private set; } = "User";
        public bool IsActive { get; private set; } = true;

        public Employee() { }

        public Employee(string name, string role, string email, string phone, string passwordHash)
        {
            Id = Guid.NewGuid();
            Name = name;
            Role = role;
            Email = email;
            Phone = phone;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
        }
    }
}

namespace Sofis.Api.Domain.Entities
{
    public enum Role
    {
        User,
        Psicólogo,
        Psicopedagogo
    }
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsTwoFactorEnabled { get; set; } = false;
        public string? TwoFactorSecret { get; set; }

        public Employee() { }

        public Employee(string name, Role role, string email, string phone, byte[] passwordHash, byte[] passwordSalt)
        {
            Id = Guid.NewGuid();
            Name = name;
            Role = role;
            Email = email;
            Phone = phone;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }
    }
}

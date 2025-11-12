using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Dtos.EmployeeDtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.User;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}

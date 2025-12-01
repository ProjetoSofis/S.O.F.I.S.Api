using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Dtos.EmployeeDtos
{
    public class UpdateEmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public Role Role { get; set; }
        public bool IsActive { get; set; }
        public string? Password { get; set; }
        public bool IsTwoFactorEnabled { get; set; }
    }
}

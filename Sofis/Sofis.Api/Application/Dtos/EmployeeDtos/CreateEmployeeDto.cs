using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Dtos.EmployeeDtos
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public Role Role { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}

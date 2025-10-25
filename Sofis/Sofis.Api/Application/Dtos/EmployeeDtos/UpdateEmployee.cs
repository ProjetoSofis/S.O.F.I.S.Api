namespace Sofis.Api.Application.Dtos.EmployeeDtos
{
    public class UpdateEmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}

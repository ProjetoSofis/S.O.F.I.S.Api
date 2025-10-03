namespace Sofis.Api.Application.Dtos
{
    public class RegistryDto
    {
        public Guid Id { get; set; }
        public Guid ChildId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
    }
}

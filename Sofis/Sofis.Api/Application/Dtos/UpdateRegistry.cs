namespace Sofis.Api.Application.Dtos
{
    public class UpdateRegistry
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

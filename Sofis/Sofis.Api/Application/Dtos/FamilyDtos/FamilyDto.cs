namespace Sofis.Api.Application.Dtos.FamilyDtos
{
    public record FamilyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int GuardianCount { get; set;}
        public int ChildrenCount { get; set; }
    }
}

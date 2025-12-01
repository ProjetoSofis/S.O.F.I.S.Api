using Sofis.Api.Application.Dtos.GuardianDtos;

namespace Sofis.Api.Application.Contracts
{
    public interface IGuardianService
    {
        Task<GuardianDto> CreateGuardianAsync(CreateGuardianDto dto);
        Task<ICollection<GuardianDto>> GetAllGuardiansAsync();
        Task<GuardianDto?> GetGuardianByIdAsync(Guid id);
        Task UpdateGuardianAsync(Guid id, CreateGuardianDto dto);
        Task DeleteGuardianAsync(Guid id);
    }
}

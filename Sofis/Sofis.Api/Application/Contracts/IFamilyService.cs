using Sofis.Api.Application.Dtos.FamilyDtos;
using Sofis.Api.Application.Dtos.GuardianDtos;

namespace Sofis.Api.Application.Contracts
{
    public interface IFamilyService
    {
        Task<FamilyDto> CreateFamilyAsync(CreateFamilyDto dto);
        Task<ICollection<FamilyDto>> GetAllFamiliesAsync();
        Task<FamilyDto?> GetFamilyByIdAsync(Guid id);
        Task UpdateFamilyAsync(Guid id, CreateFamilyDto dto);
        Task DeleteFamilyAsync(Guid id);
        Task<FamilyDto?> GetFamilyByGuardianCpfAsync(string cpf);
    }
}

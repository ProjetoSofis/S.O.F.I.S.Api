using Sofis.Api.Application.Dtos.FamilyDtos;
using Sofis.Api.Application.Dtos.GuardianDtos;

namespace Sofis.Api.Application.Contracts
{
    public interface IFamilyService
    {
        //Task<FamilyDto> RegisterFamilyAsync(CreateFamilyDto dto);
        //Task<IEnumerable<FamilyDto>> GetAllAsync();
        Task<GuardianDto> RegisterGuardianForChildAsync(CreateGuardianDto dto);
        Task<GuardianDto> GetGuardianByIdAsync(Guid id);
        Task DeleteGuardianAsync(Guid id);
        //Task<FamilyDto?> GetByIdAsync(Guid id);
        //Task<FamilyDto?> GetByCpf(string cpf);
        //Task<FamilyDto> UpdateFamilyAsync(UpdateFamilyDto dto);
        //Task DeleteFamilyAsync(Guid id);
    }
}

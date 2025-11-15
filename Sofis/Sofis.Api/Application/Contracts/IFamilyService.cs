using Sofis.Api.Application.Dtos.FamilyDtos;

namespace Sofis.Api.Application.Contracts
{
    public interface IFamilyService
    {
        Task<FamilyDto> RegisterFamilyAsync(CreateFamilyDto dto);
        Task<IEnumerable<FamilyDto>> GetAllAsync();
        Task<FamilyDto?> GetByIdAsync(Guid id);
        Task<FamilyDto?> GetByCpf(string cpf);
        Task<FamilyDto> UpdateFamilyAsync(UpdateFamilyDto dto);
        Task DeleteFamilyAsync(Guid id);
    }
}

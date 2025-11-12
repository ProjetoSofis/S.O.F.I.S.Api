using Sofis.Api.Application.Dtos;
using Sofis.Api.Application.Dtos.ChildDtos;

namespace Sofis.Api.Application.Contracts
{
    public interface IChildService
    {
        Task<ChildDto> RegisterChildAsync(CreateChildDto dto);
        Task<IEnumerable<ChildDto>> GetAllAsync();
        Task<ChildDto?> GetByIdAsync(Guid id);
        Task<ChildDto?> GetByCpfASync(string cpf);
        Task<IEnumerable<ChildDto>> GetByNameAsync(string name);
        Task<ChildDto> UpdateChildAsync(UpdateChildDto dto);
        
    }
}

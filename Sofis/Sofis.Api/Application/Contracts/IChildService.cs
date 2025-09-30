using Sofis.Api.Application.Dtos;

namespace Sofis.Api.Application.Contracts
{
    public interface IChildService
    {
        Task<ChildDto> RegisterChildAsync(CreateChildDto dto);
        Task<IEnumerable<ChildDto>> GetAllAsync();
        Task<ChildDto?> GetByIdAsync(Guid id);
        
    }
}

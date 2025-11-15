using Sofis.Api.Domain.Entities;

namespace Sofis.Api.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Employee employee);
    }
}

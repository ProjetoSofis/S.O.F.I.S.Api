using Sofis.Api.Application.Dtos.LoginDtos;

namespace Sofis.Api.Application.Contracts
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        Task<LoginResponseDto> VerifyTwoFactor(TwoFactorLoginDto twoFactorLoginDto);
    }
}

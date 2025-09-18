using Sofis.Api.Application.Dtos;
using System.Security.Cryptography;

namespace Sofis.Api.Infrastructure.Identity
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITwoFactorRepository _twoFactorRepository;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;

        public AuthService(
            IUserRepository userRepository,
            ITwoFactorRepository twoFactorRepository,
            IEmailService emailService,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _twoFactorRepository = twoFactorRepository;
            _emailService = emailService;
            _tokenService = tokenService;
        }
        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !user.CheckPassword(request.Senha))
            {
                throw new UnauthorizedAccessException("Credenciais invalidás.");
            }
            var code = RandomNumberGenerator.GetInt32(100000, 999999).ToString();

            await _twoFactorRepository.SaveCodeAsync(user.Email, code, TimeSpan.FromMinutes(5));

            await _emailService.SendEmailAsync(user.Email, "Seu código de acesso", $"Seu código é: {code}");

            return new LoginResponseDto
            {
                Requires2FA = true,
                Message = "Um código foi enviado para seu e-mail."
            };
        }
        public async Task<string> Verify2FAAsync(Verify2FACodeDto request)
        {
            var isValid = await _twoFactorRepository.ValidateCodeAsync(request.Email, request.Code);

            if (!isValid)
            {
                throw new UnauthorizedAccessException("Código inválido ou expirado.");
            }
            var user = await _userRepository.GetByEmailAsync(request.Email);

            return _tokenService.Generate(user);
        }
    }
}

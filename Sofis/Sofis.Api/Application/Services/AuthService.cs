using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.LoginDtos;
using Sofis.Api.Application.Interfaces;
using Google;
using Google.Authenticator;

namespace Sofis.Api.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        public AuthService(IEmployeeRepository employeeRepository, IPasswordService passwordService, ITokenService tokenService, IEmailService emailService)
        {
            _employeeRepository = employeeRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _emailService = emailService;
        }
        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            var employee= await _employeeRepository.GetByEmailAsync(loginDto.Email);
            if (employee == null)
            {
                throw new UnauthorizedAccessException("Credenciais inválidas");
            }
            bool isPasswordValid = _passwordService.verifyPasswordHash(loginDto.Password,
                employee.PasswordHash, employee.PasswordSalt);
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("Credenciais inválidas");
            }
            if (employee.IsTwoFactorEnabled)
            {
                var code = new Random().Next(100000, 999999).ToString("D6");

                employee.TwoEmailCode = code;
                employee.TwoFactorEmailCodeExpiration = DateTime.UtcNow.AddMinutes(10);
                await _employeeRepository.UpdateAsync(employee);
                var subject = "Seu código de verificação de dois fatores";
                var body = $"Olá {employee.Name}, <br><br>Seu código de autenticação é: <strong>{code}</strong><br><br>Este código expira em 10 minutos.";
                await _emailService.SendEmailAsync(employee.Email, subject, body);
                return new LoginResponseDto { IsTwoFactorRequired = true };
            }

            var token = _tokenService.GenerateToken(employee);
            return new LoginResponseDto
            {
                IsTwoFactorRequired = false,
                AcessToken = token
            };
        }

        public async Task<LoginResponseDto> VerifyTwoFactor(TwoFactorLoginDto twoFactorLoginDto)
        {
            var employee = await _employeeRepository.GetByEmailAsync(twoFactorLoginDto.Email);
            if (employee == null || !employee.IsTwoFactorEnabled || string.IsNullOrEmpty(employee.TwoEmailCode))
            {
                throw new UnauthorizedAccessException("Verificação 2FA falhou ou 2FA não está configurado");
            }
            if (!employee.IsTwoFactorEnabled || string.IsNullOrEmpty(employee.TwoEmailCode) || !employee.TwoFactorEmailCodeExpiration.HasValue)
            {
                throw new UnauthorizedAccessException("Verificação 2FA falhou ou não foi iniciada.");
            }
            if (employee.TwoFactorEmailCodeExpiration < DateTime.UtcNow)
            {
                employee.TwoFactorEmailCodeExpiration = null;
                employee.TwoEmailCode = null;
                await _employeeRepository.UpdateAsync(employee);
                throw new UnauthorizedAccessException("Código 2FA expirado");
            }
            if (employee.TwoEmailCode != twoFactorLoginDto.TwoFactorCode)
            {
                throw new UnauthorizedAccessException("Código 2FA inválido");
            };
            employee.TwoEmailCode = null;
            employee.TwoFactorEmailCodeExpiration = null;
            await _employeeRepository.UpdateAsync(employee);
            var token = _tokenService.GenerateToken(employee);
            var tfa = new TwoFactorAuthenticator();
            //bool isCodeValid = tfa.ValidateTwoFactorPIN(employee.TwoFactorSecret, twoFactorLoginDto.TwoFactorCode);
            //if (!isCodeValid)
            //{
            //    throw new UnauthorizedAccessException("Código 2FA inválido ou expirado");
            //}
            //var token = _tokenService.GenerateToken(employee);
            return new LoginResponseDto
            {
                IsTwoFactorRequired = false,
                AcessToken = token
            };
        }
    }
}

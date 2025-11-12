using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Dtos.LoginDtos;

namespace Sofis.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var response = await _authService.LoginAsync(loginDto);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }

        [HttpPost("verify-2fa")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyTwoFactor([FromBody] TwoFactorLoginDto twoFactorLoginDto)
        {
            try
            {
                var response = await _authService.VerifyTwoFactor(twoFactorLoginDto);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}

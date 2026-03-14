using AppPenilaianSiswaAPI.DTOs.Auths;
using AppPenilaianSiswaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppPenilaianSiswaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthsController(IAuthService ser)
        {
            _authService = ser;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] LoginRequestDTO login)
        {
            try
            {
                var Operator = await _authService.Login(login);
                if (Operator == null) return NotFound(new { message = $"Tidak ditemukan operator dengan username {login.Username}" });
                return Ok(Operator);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

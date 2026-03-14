using AppPenilaianSiswaAPI.DTOs.Auths;

namespace AppPenilaianSiswaAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> Login(LoginRequestDTO data);
    }
}

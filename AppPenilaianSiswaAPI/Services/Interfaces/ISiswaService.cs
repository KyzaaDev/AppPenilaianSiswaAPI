using AppPenilaianSiswaAPI.DTOs.Siswas;

namespace AppPenilaianSiswaAPI.Services.Interfaces
{
    public interface ISiswaService
    {
        Task<IEnumerable<SiswaResponseDTO>> GetAllAsync();
        Task<SiswaResponseDTO> CreateSiswa(SiswaCreateDTO siswaBaru);
        Task<SiswaResponseDTO> GetById(int id);
        Task<bool> DeleteSiswa(int id);
    }
}

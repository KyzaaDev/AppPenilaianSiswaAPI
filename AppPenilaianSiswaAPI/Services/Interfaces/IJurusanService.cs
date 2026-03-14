using AppPenilaianSiswaAPI.DTOs.Jurusans;

namespace AppPenilaianSiswaAPI.Services.Interfaces
{
    public interface IJurusanService
    {
        Task<IEnumerable<JurusanResponseDTO>> GetAllJurusan();
        Task<JurusanResponseDTO> CreateJurusan(JurusanCreateDTO newJurusan);
        Task<bool> DeleteJurusan(int id);
        Task<JurusanResponseDTO> GetById(int id);

    }
}

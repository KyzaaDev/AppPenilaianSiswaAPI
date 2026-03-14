using AppPenilaianSiswaAPI.DTOs.Kelas;

namespace AppPenilaianSiswaAPI.Services.Interfaces
{
    public interface IKelasService
    {
        Task<IEnumerable<KelasResponseDTO>> GetAllKelas();
    }
}

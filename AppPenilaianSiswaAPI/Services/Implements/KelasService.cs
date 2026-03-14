using AppPenilaianSiswaAPI.Data;
using AppPenilaianSiswaAPI.DTOs.Kelas;
using AppPenilaianSiswaAPI.DTOs.Jurusans;
using AppPenilaianSiswaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppPenilaianSiswaAPI.Services.Implements
{
    public class KelasService : IKelasService
    {
        private readonly AppDbContext _context;
        public KelasService(AppDbContext con)
        {
            _context = con;    
        }

        public async Task<IEnumerable<KelasResponseDTO>> GetAllKelas()
        {
            var daftarKelas = await _context.Kelas.Select(dk => new KelasResponseDTO
            {
                KelasId = dk.KelasId,
                KelasName = dk.NamaKelas,
                Jurusan = new JurusanResponseDTO
                {
                    JurusanId = dk.JurusanId,
                    JurusanName = dk.Jurusan.NamaJurusan
                },
            }).ToListAsync();

            if (!daftarKelas.Any()) return null;
            return daftarKelas;
        }
    }
}

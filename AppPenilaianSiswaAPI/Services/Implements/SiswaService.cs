using AppPenilaianSiswaAPI.Data;
using AppPenilaianSiswaAPI.DTOs.Siswas;
using AppPenilaianSiswaAPI.Models;
using AppPenilaianSiswaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppPenilaianSiswaAPI.Services.Implements
{
    public class SiswaService : ISiswaService
    {
        private readonly AppDbContext _context;
        public SiswaService(AppDbContext con)
        {
            _context = con;
        }

        public async Task<IEnumerable<SiswaResponseDTO>> GetAllAsync()
        {
            var allSiswa = await _context.Siswas.Select(s => new SiswaResponseDTO
            {
                SiswaId = s.SiswaId,
                Nisn = s.Nisn,
                NamaSiswa = s.NamaSiswa,
                Kelas = s.Kelas.NamaKelas,
                Jurusan = s.Kelas.Jurusan.NamaJurusan,
                Picture = s.SiswaPicture,
            }).ToListAsync();

            if (!allSiswa.Any()) return null;

            return allSiswa;
        }

        public async Task<SiswaResponseDTO> CreateSiswa(SiswaCreateDTO siswaBaru)
        {
            var kelas = await _context.Kelas.Include(k => k.Jurusan).FirstOrDefaultAsync(k => k.KelasId == siswaBaru.KelasId);
            if (kelas == null) throw new Exception($"Tidak ada kelas dengan ID {siswaBaru.KelasId}");

            var dataBaru = new Siswa
            {
                NamaSiswa = siswaBaru.NamaSiswa,
                Nisn = siswaBaru.Nisn,
                KelasId = siswaBaru.KelasId,
                SiswaPicture = siswaBaru.Picture
            };

            _context.Siswas.Add(dataBaru);
            await _context.SaveChangesAsync();

            return new SiswaResponseDTO
            {
                SiswaId = dataBaru.SiswaId,
                Nisn = dataBaru.Nisn,
                NamaSiswa = dataBaru.NamaSiswa,
                Kelas = kelas.NamaKelas,
                Jurusan = kelas.Jurusan.NamaJurusan,
                Picture = dataBaru.SiswaPicture,
            };
        }

        public async Task<SiswaResponseDTO> GetById(int id)
        {
            var s = await _context.Siswas.Include(s => s.Kelas).ThenInclude(s => s.Jurusan).FirstOrDefaultAsync(s => s.SiswaId == id);
            if (s == null) throw new Exception($"Tidak ditemukan siswa dengan ID {id}");
            
            return new SiswaResponseDTO
            {
                SiswaId = s.SiswaId,
                Nisn = s.Nisn,
                NamaSiswa = s.NamaSiswa,
                Kelas = s.Kelas.NamaKelas,
                Jurusan = s.Kelas.Jurusan.NamaJurusan,
                Picture = s.SiswaPicture, 
            };
        }

        public async Task<bool> DeleteSiswa(int id)
        {
            var user = await _context.Siswas.FirstOrDefaultAsync(s => s.SiswaId == id);
            if (user == null) throw new Exception($"Tidak ditemukan user dengan ID {id}");

            _context.Siswas.Remove(user);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<SiswaResponseDTO> UpdateSiswa(SiswaUpdateDTO updSiswa, int id)
        {
            var siswa = await _context.Siswas.Include(s => s.Kelas).ThenInclude(s => s.Jurusan).FirstOrDefaultAsync(s => s.SiswaId == id);
            if (siswa == null) throw new Exception($"Data siswa dengan ID {id} tidak ditemukan");

            siswa.Nisn = updSiswa.Nisn;
            siswa.NamaSiswa = updSiswa.NamaSiswa;
            siswa.KelasId = updSiswa.KelasId;
            siswa.SiswaPicture = updSiswa.Picture;

            await _context.SaveChangesAsync();
            siswa = await _context.Siswas.Include(s => s.Kelas).ThenInclude(s => s.Jurusan).FirstOrDefaultAsync(s => s.SiswaId == id);

            return new SiswaResponseDTO
            {
                SiswaId = siswa.SiswaId,
                Nisn = siswa.Nisn,
                NamaSiswa = siswa.NamaSiswa,
                Kelas = siswa.Kelas.NamaKelas,
                Jurusan = siswa.Kelas.Jurusan.NamaJurusan,
                Picture = siswa.SiswaPicture,
            };
        }
    }
}

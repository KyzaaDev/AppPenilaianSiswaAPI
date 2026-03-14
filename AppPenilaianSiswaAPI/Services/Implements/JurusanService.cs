using AppPenilaianSiswaAPI.Data;
using AppPenilaianSiswaAPI.DTOs.Jurusans;
using AppPenilaianSiswaAPI.Models;
using AppPenilaianSiswaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
namespace AppPenilaianSiswaAPI.Services.Implements
{
    public class JurusanService : IJurusanService
    {
        private readonly AppDbContext _context;
        public JurusanService(AppDbContext con)
        {
            _context = con;
        }

        public async Task<IEnumerable<JurusanResponseDTO>> GetAllJurusan()
        {
            var jurusans = await _context.Jurusans.Select(j => new JurusanResponseDTO
            {
                JurusanId = j.JurusanId,
                JurusanName = j.NamaJurusan,
            }).ToListAsync();

            if (!jurusans.Any()) return null;
            return jurusans;
        }

        public async Task<JurusanResponseDTO> CreateJurusan(JurusanCreateDTO newJurusan)
        {
            var jurusanBaru = new Jurusan
            {
                NamaJurusan = newJurusan.JurusanName,
            };

            _context.Jurusans.Add(jurusanBaru);
            await _context.SaveChangesAsync();

            return new JurusanResponseDTO
            {
                JurusanId = jurusanBaru.JurusanId,
                JurusanName = jurusanBaru.NamaJurusan,
            };
        }

        public async Task<bool> DeleteJurusan(int id)
        {
            var jurusan = await _context.Jurusans.FindAsync(id);
            if (jurusan == null) return false;

            _context.Jurusans.Remove(jurusan);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<JurusanResponseDTO> GetById(int id)
        {
            var data = await _context.Jurusans.FirstOrDefaultAsync(u => u.JurusanId == id);
            if (data == null) return null;
            return new JurusanResponseDTO
            {
                JurusanId = data.JurusanId,
                JurusanName = data.NamaJurusan,
            };
        }
    }
}

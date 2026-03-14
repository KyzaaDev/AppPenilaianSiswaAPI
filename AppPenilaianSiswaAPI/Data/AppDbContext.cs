using AppPenilaianSiswaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppPenilaianSiswaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        // public db set
        public DbSet<Nilai> Nilais { get; set; }
        public DbSet<Siswa> Siswas { get; set; }
        public DbSet<Mapel> Mapels { get; set; }
        public DbSet<Operator> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Guru> Gurus { get; set; }
        public DbSet<Kelas> Kelas { get; set; }
        public DbSet<Jurusan> Jurusans { get; set; }
    }
}

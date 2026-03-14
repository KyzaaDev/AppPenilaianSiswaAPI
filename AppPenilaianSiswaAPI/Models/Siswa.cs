using System.ComponentModel.DataAnnotations;

namespace AppPenilaianSiswaAPI.Models
{
    public class Siswa
    {
        [Key]
        public int SiswaId { get; set; }

        [Required]
        [StringLength(10)]
        public string Nisn { get; set; }

        [Required]
        [StringLength(50)]
        public string NamaSiswa { get; set; }

        [Required]
        public int KelasId { get; set; }
        public Kelas Kelas { get; set; }

        [StringLength(255)]
        public string SiswaPicture { get; set; }

        public List<Nilai> Nilais { get; set; } = new List<Nilai> { };
    }
}

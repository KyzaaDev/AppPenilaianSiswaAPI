using System.ComponentModel.DataAnnotations;

namespace AppPenilaianSiswaAPI.Models
{
    public class Nilai
    {
        [Key]
        public int NilaiId { get; set; }

        [Required]
        public int SiswaId { get; set; }
        public Siswa Siswa { get; set; }

        [Required]
        public int MapelId { get; set; }
        public Mapel Mapel { get; set; }

        [Required]
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }

        [Required]
        public int NilaiSiswa { get; set; }
    }
}

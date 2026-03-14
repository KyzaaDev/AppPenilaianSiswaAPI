using System.ComponentModel.DataAnnotations;

namespace AppPenilaianSiswaAPI.Models
{
    public class Kelas
    {
        [Key]
        public int KelasId { get; set; }

        [Required]
        public int JurusanId { get; set; }
        public Jurusan Jurusan { get; set; }

        [Required]
        [StringLength(50)]
        public string NamaKelas { get; set; }
    }
}

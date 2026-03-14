using System.ComponentModel.DataAnnotations;

namespace AppPenilaianSiswaAPI.Models
{
    public class Jurusan
    {
        [Key]
        public int JurusanId { get; set; }

        [Required]
        [StringLength(50)]
        public string NamaJurusan { get; set; }

        public List<Kelas> Kelas { get; set; } = new List<Kelas>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace AppPenilaianSiswaAPI.Models
{
    public class Mapel
    {
        [Key]
        public int MapelId { get; set; }

        [Required]
        [StringLength(50)]
        public string NamaMapel { get; set; }


        [Required]
        public int GuruId { get; set; }
        public Guru Guru { get; set; }

        public List<Nilai> Nilais { get; set; } = new List<Nilai> { };
    }
}

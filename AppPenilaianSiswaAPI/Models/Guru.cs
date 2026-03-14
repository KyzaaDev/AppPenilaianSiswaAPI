using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace AppPenilaianSiswaAPI.Models
{
    public class Guru
    {
        [Key]
        public int GuruId { get; set; }

        [Required]
        [StringLength(50)]
        public string GuruName { get; set; }

        public List<Mapel> Mapels { get; set; } = new List<Mapel>();
    }
}

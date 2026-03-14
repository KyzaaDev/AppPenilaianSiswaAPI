using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AppPenilaianSiswaAPI.Models
{
    public class Operator
    {
        [Key]
        public int OperatorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(70)]
        public string Nama { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}

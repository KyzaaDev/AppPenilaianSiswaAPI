namespace AppPenilaianSiswaAPI.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<Operator> Users { get; set; } = new List<Operator>();
    }
}

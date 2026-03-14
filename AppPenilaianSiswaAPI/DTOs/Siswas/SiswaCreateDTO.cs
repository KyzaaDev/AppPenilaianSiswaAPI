namespace AppPenilaianSiswaAPI.DTOs.Siswas
{
    public class SiswaCreateDTO
    {
        public string Nisn { get; set; }
        public string NamaSiswa { get; set; }
        public int KelasId { get; set; } = 0;
        public string Picture { get; set; }
    }
}

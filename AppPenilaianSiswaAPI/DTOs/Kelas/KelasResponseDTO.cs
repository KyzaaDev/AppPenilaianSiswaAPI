using AppPenilaianSiswaAPI.DTOs.Jurusans;

namespace AppPenilaianSiswaAPI.DTOs.Kelas
{
    public class KelasResponseDTO
    {
        public int KelasId { get; set; }
        public string KelasName { get; set; }
        public JurusanResponseDTO Jurusan { get; set; }
    }
}

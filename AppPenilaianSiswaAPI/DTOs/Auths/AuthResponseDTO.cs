namespace AppPenilaianSiswaAPI.DTOs.Auths
{
    public class AuthResponseDTO
    {
        public int OperatorId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}

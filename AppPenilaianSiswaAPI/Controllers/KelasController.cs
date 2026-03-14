using AppPenilaianSiswaAPI.DTOs.Kelas;
using AppPenilaianSiswaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppPenilaianSiswaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KelasController : ControllerBase
    {
        private readonly IKelasService _kelasService;
        public KelasController(IKelasService ser)
        {
            _kelasService = ser;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KelasResponseDTO>>> GetAllKelas()
        {
            var allKelas = await _kelasService.GetAllKelas();
            if (allKelas == null) return NotFound(new { message = "Data kelas masih kosong!" });
            return Ok(allKelas);
        }
    }
}

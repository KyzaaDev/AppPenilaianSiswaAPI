using AppPenilaianSiswaAPI.DTOs.Siswas;
using AppPenilaianSiswaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppPenilaianSiswaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiswasController : ControllerBase
    {
        private readonly ISiswaService _siswaService;
        public SiswasController(ISiswaService ser)
        {
            _siswaService = ser;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SiswaResponseDTO>>> GetAllAsync()
        {
            var daftarSiswa = await _siswaService.GetAllAsync();
            if (daftarSiswa == null) return NotFound(new { message = "Data siswa masih kosong!" });
            return Ok(daftarSiswa);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SiswaResponseDTO>> GetById(int id)
        {
            try
            {
                var siswa = await _siswaService.GetById(id);
                return siswa;
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<SiswaResponseDTO>> CreateSiswa([FromBody] SiswaCreateDTO siswaData)
        {
            try
            {
                var siswaBaru = await _siswaService.CreateSiswa(siswaData);
                return CreatedAtAction(nameof(GetById), new { id = siswaBaru.SiswaId }, siswaBaru);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteSiswa(int id)
        {
            try
            {
                var siswa = await _siswaService.DeleteSiswa(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
            
            
        }
    }
}

using AppPenilaianSiswaAPI.DTOs.Jurusans;
using AppPenilaianSiswaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppPenilaianSiswaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JurusansController : ControllerBase
    {
        private readonly IJurusanService _jurusanService;
        public JurusansController(IJurusanService ser)
        {
            _jurusanService = ser;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JurusanResponseDTO>>> GetAll()
        {
            var jurusans = await _jurusanService.GetAllJurusan();
            return Ok(jurusans);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJurusan(int id)
        {
            var dataJurusan = await _jurusanService.DeleteJurusan(id);
            if (!dataJurusan) return NotFound(new { message = $"Jurusan dengan ID {id} tidak ditemukan" });
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JurusanResponseDTO>> GetById(int id)
        {
            var dataJurusan = await _jurusanService.GetById(id);
            if (dataJurusan == null) return NotFound(new { message = $"Tidak ada jurusan dengan ID {id}" });
            return dataJurusan;

        }


        [HttpPost]
        public async Task<ActionResult<JurusanResponseDTO>> CreateJurusan([FromBody] JurusanCreateDTO data)
        {
            var newJurusan = await _jurusanService.CreateJurusan(data);
            return Ok(newJurusan);
        }
    }
}

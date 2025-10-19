using Microsoft.AspNetCore.Mvc;
using HBoostUltra.Services;
using System.Threading.Tasks;

namespace HBoostUltra.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MercadoPagoController : ControllerBase
    {
        private readonly MercadoPagoService _mpService;

        public MercadoPagoController()
        {
            _mpService = new MercadoPagoService();
        }

        [HttpGet("CreatePreference")]
        public async Task<IActionResult> CreatePreference()
        {
            try
            {
                var preferenceId = await _mpService.CrearPreferenciaAsync();
                return Ok(new { preferenceId });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Error al conectarse con MercadoPago.", detalle = ex.Message });
            }
        }
    }
}

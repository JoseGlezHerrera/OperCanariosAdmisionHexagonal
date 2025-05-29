using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.ObtenerVisitasPorFecha;

namespace Oper.Admision.Api.UseCases.Visitas.ObtenerVisitasPorFecha
{
    [ApiController]
    [Route("api/visitas/[controller]")]
    public class ObtenerVisitasPorFechaController : ControllerBase
    {
        private readonly ObtenerVisitasPorFechaUseCase _useCase;
        public ObtenerVisitasPorFechaController(ObtenerVisitasPorFechaUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpGet("{fecha}")]
        public async Task<IActionResult> Get(DateTime fecha)
        {
            var input = new ObtenerVisitasPorFechaInput(fecha);
            var result = await _useCase.EjecutarAsync(input);
            if (result == null || !result.Any())
                return NotFound($"No se encontraron visitas para la fecha {fecha.ToShortDateString()}.");
            return Ok(result);
        }
    }
}

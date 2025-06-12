using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visita.ObtenerVisitaPorId;
using Oper.Admision.Application.UseCases.Visitas.ObtenerVisitaPorId;

namespace Oper.Admision.Api.UseCases.Visitas.ObtenerVisitaPorId
{
    [ApiController]
    [Route("api/visitas")]
    public class ObtenerVisitaPorIdController : ControllerBase
    {
        private readonly ObtenerVisitaPorIdUseCase _useCase;
        public ObtenerVisitaPorIdController(ObtenerVisitaPorIdUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpGet("por-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var input = new ObtenerVisitaPorIdInput(id);
                var result = await _useCase.EjecutarAsync(input);

                if (result == null)
                    return NotFound(new { status = "error", mensaje = $"No se encontró una visita con el ID {id}." });

                return Ok(new { status = "success", datos = result });
            }
            catch (Exception)
            {
                return StatusCode(500, new { status = "error", mensaje = "Error interno al obtener la visita." });
            }
        }
    }
}
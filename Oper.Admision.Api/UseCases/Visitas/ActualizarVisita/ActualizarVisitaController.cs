using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.ActualizarVisita;

namespace Oper.Admision.Api.UseCases.Visitas.ActualizarVisita
{
    [ApiController]
    [Route("api/visitas/actualizar")]
    public class ActualizarVisitaController : ControllerBase
    {
        private readonly ActualizarVisitaUseCase _useCase;

        public ActualizarVisitaController(ActualizarVisitaUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarVisitaInput input)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { status = "error", mensaje = "Datos inválidos." });

            try
            {
                await _useCase.EjecutarAsync(input);
                return Ok(new { status = "success", mensaje = "Visita actualizada correctamente" });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { status = "error", mensaje = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { status = "error", mensaje = "Error interno al actualizar la visita." });
            }
        }
    }
}
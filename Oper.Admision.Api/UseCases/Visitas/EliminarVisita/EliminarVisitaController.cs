using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visita.EliminarVisita;

namespace Oper.Admision.Api.UseCases.Visitas.EliminarVisita
{
    [ApiController]
    [Route("api/visitas/eliminar")]
    public class EliminarVisitaController : ControllerBase
    {
        private readonly EliminarVisitaUseCase _useCase;

        public EliminarVisitaController(EliminarVisitaUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _useCase.Handle(id);
                return Ok(new { status = "success", mensaje = "Visita eliminada correctamente" });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { status = "error", mensaje = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { status = "error", mensaje = "Error interno al eliminar la visita." });
            }
        }

    }
}
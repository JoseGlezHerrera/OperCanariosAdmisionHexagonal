using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.ActualizarVisita;

namespace Oper.Admision.Api.UseCases.Visitas.ActualizarVisita
{
    [ApiController]
    [Route("api/[controller]")]
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
            await _useCase.EjecutarAsync(input);
            return Ok(new { mensaje = "Visita actualizada correctamente" });
        }
    }
}
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
        public async Task<IActionResult> EliminarVisita(int id)
        {
            var input = new EliminarVisitaInput(id);
            var mensaje = await _useCase.EjecutarAsync(input);
            return Ok(new { message = mensaje });
        }
    }
}
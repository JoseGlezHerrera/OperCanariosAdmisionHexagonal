using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Socios.EliminarSocio;
namespace Oper.Admision.Api.UseCases.Socios.EliminarSocio
{
    [Route("api/socios/eliminar")]
    [ApiController]
    public class EliminarSocioController : ControllerBase
    {
        private readonly EliminarSocioUseCase _useCase;
        public EliminarSocioController(EliminarSocioUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar (int id)
        {
            var input = new EliminarSocioInput(id);
            await _useCase.EjecutarAsync(input);
            return Ok(new { mensaje = $"Socio {input.Id} eliminado correctamente." });

        }
    }
}

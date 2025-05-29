using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visita.ObtenerVisitaPorId;
using Oper.Admision.Application.UseCases.Visitas.ObtenerVisitaPorId;

namespace Oper.Admision.Api.UseCases.Visitas.ObtenerVisitaPorId
{
    [ApiController]
    [Route("api/visitas/[controller]")]
    public class ObtenerVisitaPorIdController : ControllerBase
    {
        private readonly ObtenerVisitaPorIdUseCase _useCase;
        public ObtenerVisitaPorIdController(ObtenerVisitaPorIdUseCase useCase)
        {

            _useCase = useCase;
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var input = new ObtenerVisitaPorIdInput(id);
            var result = await _useCase.EjecutarAsync(input);
            if (result == null)
                return NotFound($"No se encontró una visita con el ID {id}.");
            return Ok(result);
        }
    }
}

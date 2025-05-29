using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.ListarVisitasPorSocio;

namespace Oper.Admision.Api.UseCases.Visitas.ListarVisitasPorSocio
{
    [ApiController]
    [Route("api/visitas")]
    public class ListarVisitasPorSocioController : ControllerBase
    {
        private readonly ListarVisitasPorSocioUseCase _useCase;

        public ListarVisitasPorSocioController(ListarVisitasPorSocioUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("por-socio/{idSocio}")]
        public async Task<IActionResult> GetBySocioId(int idSocio)
        {
            var result = await _useCase.EjecutarAsync(idSocio);
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.ListarVisitasPorSocio;

namespace Oper.Admision.Api.UseCases.Visitas.ListarVisitasPorSocio
{
    [ApiController]
    [Route("api/visitas/[controller]")]
    public class ListarVisitasPorSocioController : ControllerBase
    {
        private readonly ListarVisitasPorSocioUseCase _useCase;

        public ListarVisitasPorSocioController(ListarVisitasPorSocioUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("{socioId}")]
        public async Task<IActionResult> Get(int socioId)
        {
            var resultado = await _useCase.EjecutarAsync(socioId);
            return Ok(resultado);
        }
    }
}
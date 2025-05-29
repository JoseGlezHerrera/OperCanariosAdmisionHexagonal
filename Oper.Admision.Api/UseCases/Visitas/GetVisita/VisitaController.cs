using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.GetVisita;

namespace Oper.Admision.Api.UseCases.Visitas.GetVisita
{
    [Route("api/[controller]")]
    [ApiController]

    public class VisitaController : ControllerBase
    {
        private readonly GetVisitaUseCase _useCase;
        private readonly IMapper _mapper;

        public VisitaController(GetVisitaUseCase useCase, IMapper mapper)
        {
            this._useCase = useCase;
            this._mapper = mapper;
        }

        [HttpGet("GetVisitas")]
        public async Task<IActionResult> GetVisitas()
        {
            var resultado = await _useCase.ExecuteAsync();
            return Ok(resultado);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.CrearVisita;

namespace Oper.Admision.Api.UseCases.Visitas.CrearVisita
{
    [Route("api/[controller]")]
    [ApiController]
    public class VistaController : ControllerBase
    {
        private readonly CrearVisitaUseCase _useCase;
        private readonly IMapper _mapper;
        public VistaController(CrearVisitaUseCase useCase, IMapper mapper)
        {
            this._useCase = useCase;
            this._mapper = mapper;
        }
        [HttpPost("CrearVisita")]
        public IActionResult Crear([FromBody] CrearVisitaRequest request)
        {
            var input = this._mapper.Map<CrearVisitaRequest, CrearVisitaInput>(request);
            var output = this._useCase.Execute(input);
            return Ok(output);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.ListarVisitasPorSocio;
using AutoMapper;

namespace Oper.Admision.Api.UseCases.Visitas.ListarVisitasPorSocio
{
    [Route("api/visitas")]
    [ApiController]
    public class ListarVisitasPorSocioController : ControllerBase
    {
        private readonly ListarVisitasPorSocioUseCase _useCase;
        private readonly IMapper _mapper;
        public ListarVisitasPorSocioController(ListarVisitasPorSocioUseCase useCase, IMapper mapper)
        {
            _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet("por-socio/{socioId}")]
        public async Task <IActionResult> ListarPorSocio(int socioId)
        {
            var input = new ListarVisitasPorSocioInput(socioId);
            var visitas = await _useCase.EjecutarAsync(input);
            var response = _mapper.Map<List<ListarVisitasPorSocioResponse>>(visitas);
            return Ok(response);
        }
    }
}

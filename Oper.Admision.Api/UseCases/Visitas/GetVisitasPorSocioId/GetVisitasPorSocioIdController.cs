using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.GetVisitasPorSocioId;

namespace Oper.Admision.Api.UseCases.Visitas.GetVisitasPorSocioId
{
    [Route("api/visitas")]
    [ApiController]
    public class GetVisitasPorSocioIdController : ControllerBase
    {
        private readonly GetVisitasPorSocioIdUseCase _useCase;
        private readonly IMapper _mapper;

        public GetVisitasPorSocioIdController(GetVisitasPorSocioIdUseCase useCase, IMapper mapper)
        {
            _useCase = useCase;
            _mapper = mapper;
        }

        [HttpGet("por-socio/{socioId}")]
        public async Task<IActionResult> GetVisitasPorSocio(int socioId)
        {
            try
            {
                var input = new GetVisitasPorSocioIdInput { SocioId = socioId };
                var output = await _useCase.Execute(input);
                var response = _mapper.Map<List<GetVisitasPorSocioIdResponse>>(output);
                return Ok(new { status = "success", datos = response });
            }
            catch (Exception)
            {
                return StatusCode(500, new { status = "error", mensaje = "Error interno al obtener visitas por socio." });
            }
        }
    }
}
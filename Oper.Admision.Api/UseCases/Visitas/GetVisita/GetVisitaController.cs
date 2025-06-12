using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.GetVisita;

namespace Oper.Admision.Api.UseCases.Visitas.GetVisita
{
    [Route("api/visitas")]
    [ApiController]

    public class GetVisitaController : ControllerBase
    {
        private readonly GetVisitaUseCase _useCase;
        private readonly IMapper _mapper;

        public GetVisitaController(GetVisitaUseCase useCase, IMapper mapper)
        {
            this._useCase = useCase;
            this._mapper = mapper;
        }

        [HttpGet("GetVisitas")]
        public async Task<IActionResult> GetVisitas()
        {
            try
            {
                var resultado = await _useCase.ExecuteAsync();
                return Ok(new { status = "success", datos = resultado });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", mensaje = "Error interno al obtener las visitas" });
            }
        }
    }
}

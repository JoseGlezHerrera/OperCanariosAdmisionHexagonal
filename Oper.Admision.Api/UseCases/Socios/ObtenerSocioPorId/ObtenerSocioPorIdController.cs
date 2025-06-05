using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Oper.Admision.Application.UseCases.Socios.ObtenerSocioPorId;


namespace Oper.Admision.Api.UseCases.Socios.ObtenerSocioPorId
{
    [Route("api/socios/obtener-por-id")]
    [ApiController]
    public class ObtenerSocioPorIDController : ControllerBase
    {
        private readonly ObtenerSocioPorIdUseCase _useCase;
        private readonly IMapper _mapper;
        public ObtenerSocioPorIDController(ObtenerSocioPorIdUseCase useCase, IMapper mapper)
        {
            _useCase = useCase;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var input  = new ObtenerSocioPorIdInput(id);
            var entidad = await _useCase.EjecutarAsync(input);
            if (entidad is null)
                return NotFound($"No se encontró un socio con el id {id}.");
            var response = _mapper.Map<ObtenerSocioPorIdResponse>(entidad);
            return Ok(response);

        }
    }
}

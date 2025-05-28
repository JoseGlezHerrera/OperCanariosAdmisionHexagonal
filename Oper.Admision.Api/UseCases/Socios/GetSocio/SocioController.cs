using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Api.UseCases.Socios.ObtenerCumpleañeros;
using Oper.Admision.Application.UseCases.Socios.GetSocio;

namespace Oper.Admision.Api.UseCases.Socios.GetSocio
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly GetSocioUseCase _useCase;
        private readonly IMapper _mapper;
        private readonly ObtenerCumpleañerosUseCase _obtenerCumplesUseCase;
        public SocioController(GetSocioUseCase useCase, IMapper mapper, ObtenerCumpleañerosUseCase obtenerCumplesUseCase)
        {
            this._useCase = useCase;
            this._mapper = mapper;
            this._obtenerCumplesUseCase = obtenerCumplesUseCase;
        }

        [HttpGet("GetSocios")]
        public IActionResult GetSocios()
        {
            return Ok(this._useCase.Execute());
        }
        [HttpGet("CumplesHoy")]
        public async Task<IActionResult> ObtenerCumpleañeros()
        {
            var resultado = await _obtenerCumplesUseCase.EjecutarAsync();
            var response = _mapper.Map<List<ObtenerCumpleañerosResponse>>(resultado);
            return Ok(response);
        }
    }
}
   
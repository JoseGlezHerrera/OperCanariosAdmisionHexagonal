using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Api.UseCases.Socios.ObtenerCumpleañeros;
using Oper.Admision.Application.UseCases.Socios.GetSocio;

namespace Oper.Admision.Api.UseCases.Socios.GetSocio
{
    [Route("api/socios")]
    [ApiController]
    public class GetSocioController : ControllerBase
    {
        private readonly GetSocioUseCase _useCase;
        private readonly IMapper _mapper;
        private readonly ObtenerCumpleañerosUseCase _obtenerCumplesUseCase;
        public GetSocioController(GetSocioUseCase useCase, IMapper mapper, ObtenerCumpleañerosUseCase obtenerCumplesUseCase)
        {
            this._useCase = useCase;
            this._mapper = mapper;
            this._obtenerCumplesUseCase = obtenerCumplesUseCase;
        }

        [HttpGet("obtener-todos")]
        public IActionResult GetSocios()
        {
            try
            {
                var resultado = this._useCase.Execute();
                return Ok(new { status = "success", datos = resultado });
            }
            catch (Exception)
            {
                return StatusCode(500, new { status = "error", mensaje = "Error interno al obtener socios." });
            }
        }
        [HttpGet("CumplesHoy")]
        public async Task<IActionResult> ObtenerCumpleañeros()
        {
            try
            {
                var resultado = await _obtenerCumplesUseCase.EjecutarAsync();
                var response = _mapper.Map<List<ObtenerCumpleañerosResponse>>(resultado);

                if (response == null || !response.Any())
                {
                    return Ok(new
                    {
                        status = "success",
                        datos = new List<ObtenerCumpleañerosResponse>(),
                        mensaje = "Ningún socio cumple años hoy."
                    });
                }

                return Ok(new
                {
                    status = "success",
                    datos = response,
                    mensaje = $"Total de cumpleañeros hoy: {response.Count}"
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    mensaje = "Error interno al obtener los cumpleañeros."
                });
            }
        }
    }
}
   
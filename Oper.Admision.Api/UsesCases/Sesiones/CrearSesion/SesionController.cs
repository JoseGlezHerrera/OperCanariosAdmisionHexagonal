using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Sesiones;
using Oper.Admision.Application.UseCases.Sesiones.CrearSesion;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UsesCases.Sesiones.CrearSesion
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private readonly CrearSesionUseCase _useCase;
        private readonly IMapper _mapper;

        public SesionController(CrearSesionUseCase useCase, IMapper mapper)
        {
            _useCase = useCase;
            _mapper = mapper;
        }
        [HttpPost("CrearSesion")]

        public IActionResult Crear([Required] CrearSesionRequest request)
        { 
            var input = _mapper.Map<CrearSesionRequest, CrearSesionInput>(request);
            var output = _useCase.Execute(input);

            return Ok(output);
        }
    }
}

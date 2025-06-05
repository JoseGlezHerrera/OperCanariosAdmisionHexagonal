using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Sesiones;
using Oper.Admision.Application.UseCases.Sesiones.CrearSesion;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UseCases.Sesiones.CrearSesion
{
    [Route("api/sesiones")]
    [ApiController]
    public class CrearSesionController : ControllerBase
    {
        private readonly CrearSesionUseCase _useCase;
        private readonly IMapper _mapper;

        public CrearSesionController(CrearSesionUseCase useCase, IMapper mapper)
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

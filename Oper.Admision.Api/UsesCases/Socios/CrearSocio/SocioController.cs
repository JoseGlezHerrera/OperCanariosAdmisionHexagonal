using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Api.UseCases.Usuarios.CrearUsuario;
using Oper.Admision.Application.UseCases.Socios.CrearSocio;
using Oper.Admision.Application.UseCases.Socios;
using Oper.Admision.Application.UseCases.Usuarios.Crear;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UsesCases.Socios.CrearSocio
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly CrearSocioUseCase _useCase;
        private readonly IMapper _mapper;
        private readonly GetTodosSociosUseCase _getTodosUseCase;

        public SocioController(CrearSocioUseCase useCase, IMapper mapper)
        {
            this._useCase = useCase;
            this._mapper = mapper;
        }

        [HttpPost("CrearSocio")]
        public IActionResult Crear([Required] CrearSocioRequest request)
        {
            var input = this._mapper.Map<CrearSocioRequest, CrearSocioInput>(request);
            var output = this._useCase.Execute(input);

            return Ok(output);
        }
        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var resultado = await _getTodosUseCase.EjecutarAsync();
            return Ok(resultado);
        }
    }
}

using AutoMapper;
using Oper.Admision.Application.UseCases.Rol.GetTodos;
using Oper.Admision.Application.UseCases.Usuarios.Crear;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UseCases.Usuarios.CrearUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly CrearUsuarioUseCase _useCase;
        private readonly IMapper _mapper;

        public UsuarioController(CrearUsuarioUseCase useCase, IMapper mapper )
        {
            this._useCase =useCase;
            this._mapper = mapper;
        }

        [HttpPost("Crear")]
        public IActionResult Crear ([Required]  CrearUsuarioRequest request)
        {
            var input = this._mapper.Map<CrearUsuarioRequest, CrearUsuarioInput>(request);
            var output = this._useCase.Execute(input);

            return Ok(output);
        }
    }
}

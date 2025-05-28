using AutoMapper;
using Oper.Admision.Application.UseCases.Rol.GetTodos;
using Oper.Admision.Application.UseCases.Usuarios.DarBajaAlta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UseCases.Usuarios.DarBajaAltaUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly DarBajaAltaUsuarioUseCase _useCase;
        private readonly IMapper _mapper;

        public UsuarioController(DarBajaAltaUsuarioUseCase useCase, IMapper mapper )
        {
            this._useCase =useCase;
            this._mapper = mapper;
        }

        [HttpPost("DarBajaAlta")]
        public IActionResult DarBajaAlta ([Required]  DarBajaAltaUsuarioRequest request)
        {
            var input = this._mapper.Map<DarBajaAltaUsuarioRequest, DarBajaAltaUsuarioInput>(request);
            var output = this._useCase.Execute(input);

            return Ok(output);
        }
    }
}

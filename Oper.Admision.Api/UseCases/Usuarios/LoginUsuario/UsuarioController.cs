using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Usuarios.Login;
using Oper.Admision.Infrastructure.Seguridad;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UseCases.Usuarios.LoginUsuario
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LoginUsuarioUseCase _useCase;
        private readonly JwtGenerator _jwtGenerator;

        public UsuarioController(IMapper mapper, LoginUsuarioUseCase useCase, JwtGenerator jwtGenerator)
        {
            this._mapper = mapper;
            this._useCase = useCase;
            this._jwtGenerator = jwtGenerator;
        }

        [HttpPost("Login")]
        public IActionResult Login([Required] LoginUsuarioRequest request)
        {
            var input = this._mapper.Map<LoginUsuarioInput>(request);
            var output = this._useCase.Execute(input);
            var response = this._mapper.Map<LoginUsuarioResponse>(output);

            response.Token = _jwtGenerator.GenerarToken(output.Usuario);

            return Ok(response);
        }
    }
}
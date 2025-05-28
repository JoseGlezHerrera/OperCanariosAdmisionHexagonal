using AutoMapper;
using Oper.Admision.Api.Seguridad;
using Oper.Admision.Application.UseCases.Usuarios.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UseCases.Usuarios.LoginUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly LoginUsuarioUseCase _useCase;
        private readonly IOptions<JWT> _jwt;
        private readonly IMapper _mapper;

        public UsuarioController(LoginUsuarioUseCase useCase, IOptions<JWT> jwt, IMapper mapper)
        {
            this._useCase = useCase;
            this._jwt = jwt;
            this._mapper = mapper;
        }

        [HttpPost("Login")]
        public IActionResult Login([Required] LoginUsuarioRequest request)
        {
            var input = this._mapper.Map<LoginUsuarioRequest, LoginUsuarioInput>(request);
            var output = this._useCase.Execute(input);
            var response = this._mapper.Map<LoginUsuarioOutput, LoginUsuarioResponse>(output);
            response.Token = TokenJWT.GenerarTokenJWT(output.UsuarioId, this._jwt.Value);
            return Ok(response);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.UseCases.Usuarios.Login;
using Oper.Admision.Api.UseCases.Usuarios.LoginUsuario;

namespace Oper.Admision.Api.UseCases.Usuarios.LoginUsuario
{
    [ApiController]
    [Route("api/usuarios")]
    public class LoginUsuarioController : ControllerBase
    {
        private readonly LoginUsuarioUseCase _loginUseCase;
        private readonly IMapper _mapper;
        private readonly ILogger<LoginUsuarioController> _logger;

        public LoginUsuarioController(
            LoginUsuarioUseCase loginUseCase,
            IMapper mapper,
            ILogger<LoginUsuarioController> logger)
        {
            _loginUseCase = loginUseCase;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUsuarioRequest request)
        {
            if (request == null)
                return BadRequest(new { mensaje = "El cuerpo de la petición es requerido." });

            try
            {
                _logger.LogInformation("Petición de login para usuario '{Nombre}'", request.Nombre);

                var inputUoC = _mapper.Map<LoginUsuarioInput>(request);
                var resultado = _loginUseCase.Execute(inputUoC);
                var response = _mapper.Map<LoginUsuarioResponse>(resultado);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _logger.LogWarning(ex, "Error en Login: {Mensaje}", ex.Message);
                return Unauthorized(new { mensaje = ex.Message });
            }
        }
    }
}
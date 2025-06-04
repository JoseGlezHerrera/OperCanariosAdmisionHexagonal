using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.UseCases.Usuarios.CambiarPassword;
using Oper.Admision.Api.UseCases.Usuarios.CambiarPasswordUsuario;

namespace Oper.Admision.Api.UseCases.Usuarios.CambiarPasswordUsuario
{
    [ApiController]
    [Route("api/usuario")]
    [Authorize]
    public class CambiarPasswordUsuarioController : ControllerBase
    {
        private readonly CambiarPasswordUsuarioUseCase _useCase;
        private readonly IMapper _mapper;
        private readonly ILogger<CambiarPasswordUsuarioController> _logger;

        public CambiarPasswordUsuarioController(
            CambiarPasswordUsuarioUseCase useCase,
            IMapper mapper,
            ILogger<CambiarPasswordUsuarioController> logger)
        {
            _useCase = useCase;
            _mapper = mapper;
            _logger = logger;
        }

        /// PUT /api/usuario/cambiar-password
        /// Recibe un JSON:
        /// {
        ///   "usuarioId": 123,
        ///   "password": "NuevaClave123"

        [HttpPut("cambiar-password")]
        public IActionResult CambiarPassword([FromBody] CambiarPasswordUsuarioRequest request)
        {
            if (request == null)
                return BadRequest(new { mensaje = "El cuerpo de la petición es requerido." });

            try
            {
                _logger.LogInformation("Petición de cambiar contraseña para UsuarioId {UsuarioId}", request.UsuarioId);

                var inputUoC = _mapper.Map<CambiarPasswordUsuarioInput>(request);

                var changed = _useCase.Execute(inputUoC);

                if (changed)
                {
                    return Ok(new { mensaje = "Contraseña cambiada correctamente." });
                }
                else
                {
                    // Si el UseCase devolvió false, significa que la nueva contraseña es igual a la actual
                    return BadRequest(new { mensaje = "La nueva contraseña es igual a la actual." });
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogWarning(ex, "Error en CambiarPassword: {Mensaje}", ex.Message);
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.UseCases.Usuarios.EliminarUsuario;

namespace Oper.Admision.Api.UseCases.Usuarios.EliminarUsuario
{
    [Route("api/usuarios/eliminar")]
    [ApiController]
    public class EliminarUsuarioController : ControllerBase
    {
        private readonly EliminarUsuarioUseCase _eliminarUsuarioUseCase;
        private readonly ILogger<EliminarUsuarioController> _logger;

        public EliminarUsuarioController(
            EliminarUsuarioUseCase eliminarUsuarioUseCase,
            ILogger<EliminarUsuarioController> logger)
        {
            _eliminarUsuarioUseCase = eliminarUsuarioUseCase;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            try
            {
                var input = new EliminarUsuarioInput { UsuarioId = id };
                var mensaje = _eliminarUsuarioUseCase.Execute(input);
                return Ok(new { mensaje });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar usuario.");
                return StatusCode(500, new { mensaje = "Error inesperado al eliminar el usuario." });
            }
        }
    }
}
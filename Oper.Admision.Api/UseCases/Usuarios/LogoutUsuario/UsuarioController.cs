using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Usuarios.LogoutUsuario;
using Oper.Admision.Domain.IRepositories;

namespace Oper.Admision.Api.UseCases.Usuarios.LogoutUsuario
{
    [ApiController]
    [Route("api/usuario/logout")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<ActionResult<LogoutUsuarioResponse>> Logout([FromBody] LogoutUsuarioRequest request)
        {
            var useCase = new LogoutUsuarioUseCase(_usuarioRepository);

            var input = new LogoutUsuarioInput
            {
                NombreUsuario = request.NombreUsuario
            };

            var result = await useCase.EjecutarAsync(input);

            var response = new LogoutUsuarioResponse
            {
                Exito = result.Exito,
                Mensaje = result.Mensaje
            };

            return Ok(response);
        }
    }
}
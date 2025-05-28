using AutoMapper;
using Oper.Admision.Application.UseCases.Rol.GetTodos;
using Oper.Admision.Application.UseCases.Usuarios.Eliminar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UseCases.Usuarios.EliminarUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly CambiarPasswordUsuarioUseCase _useCase;

        public UsuarioController(CambiarPasswordUsuarioUseCase useCase)
        {
            this._useCase = useCase;
        }

        [HttpDelete("{usuarioId}")]
        public IActionResult ELiminar(int usuarioId)
        {
            var input = new CambiarPasswordUsuarioInput() { UsuarioId = usuarioId };
            this._useCase.Execute(input);
            return Ok(true);
        }
    }
}

using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.Resetear;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UseCases.Usuarios.ResetearUsuario
{
    [Route("api/usuarios")]
    [ApiController]
    [Authorize]
    public class ResetearUsuarioController : ControllerBase
    {
        private readonly ResetearUsuarioUseCase _useCase;

        public ResetearUsuarioController(ResetearUsuarioUseCase useCase)
        {
            this._useCase = useCase;
        }

        [HttpPost("Resetear")]
        public IActionResult Resetear([Required] ResetearUsuarioRequest request)
        {
            var input = new ResetearUsuarioInput() { UsuarioId = request.UsuarioId };
            var resultado = this._useCase.Execute(input);
            return Ok(resultado);
        }
    }
}

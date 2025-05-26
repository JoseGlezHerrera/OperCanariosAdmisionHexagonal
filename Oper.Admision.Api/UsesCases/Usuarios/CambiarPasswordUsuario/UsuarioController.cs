using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.CambiarPassword;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UseCases.Usuarios.CambiarPasswordUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly CambiarPasswordUsuarioUseCase _useCase;
        private readonly IUsuarioApi _usuarioApi;

        public UsuarioController(CambiarPasswordUsuarioUseCase useCase,IUsuarioApi usuarioApi)
        {
            
            
            this._useCase = useCase;
            this._usuarioApi = usuarioApi;
        }

        [HttpPost("CambiarPassword")]
        public IActionResult CambiarPassword([Required]  CambiarPasswordUsuarioRequest request)
        {
            var input = new CambiarPasswordUsuarioInput() { Password= request.Password, UsuarioId= this._usuarioApi.UsuarioId };
            var resultado = this._useCase.Execute(input);
            return Ok(resultado);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Usuarios.CambiarPassword;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;

namespace Oper.Admision.Api.UseCases.Usuarios.CambiarPasswordUsuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly CambiarPasswordUsuarioUseCase _useCase;
        private readonly IUsuarioApi _usuarioApi;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(CambiarPasswordUsuarioUseCase useCase, IUsuarioApi usuarioApi, ILogger<UsuarioController> logger)
        {
            _useCase = useCase;
            _usuarioApi = usuarioApi;
            _logger = logger;
        }

        [HttpPost("CambiarPassword")]
        public IActionResult CambiarPassword([FromBody] CambiarPasswordUsuarioRequest request)
        {
            try
            {
                var input = new CambiarPasswordUsuarioInput
                {
                    Password = request.Password,
                    UsuarioId = _usuarioApi.UsuarioId
                };

                var result = _useCase.Execute(input);

                if (!result)
                {
                    return BadRequest(new
                    {
                        succeeded = false,
                        message = "La nueva contraseña no puede ser igual a la actual.",
                        errores = new[] { "Debe establecer una contraseña diferente." },
                        data = (object)null
                    });
                }

                return Ok(new
                {
                    succeeded = true,
                    message = "Contraseña cambiada correctamente.",
                    errores = new string[] { },
                    data = (object)null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cambiando contraseña");
                return StatusCode(500, new
                {
                    succeeded = false,
                    message = ex.Message,
                    errores = new[] { ex.InnerException?.Message },
                    data = (object)null
                });
            }
        }
    }
}
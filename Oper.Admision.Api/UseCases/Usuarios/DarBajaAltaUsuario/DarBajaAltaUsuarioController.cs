using AutoMapper;
using Oper.Admision.Application.UseCases.Rol.GetTodos;
using Oper.Admision.Application.UseCases.Usuarios.DarBajaAlta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Oper.Admision.Application.Exceptions;

namespace Oper.Admision.Api.UseCases.Usuarios.DarBajaAltaUsuario
{
    [Route("api/usuarios")]
    [ApiController]
    [Authorize]
    public class DarBajaAltaUsuarioController : ControllerBase
    {
        private readonly DarBajaAltaUsuarioUseCase _useCase;
        private readonly IMapper _mapper;

        public DarBajaAltaUsuarioController(DarBajaAltaUsuarioUseCase useCase, IMapper mapper )
        {
            this._useCase =useCase;
            this._mapper = mapper;
        }

        [HttpPost("DarBajaAlta")]
        public IActionResult DarBajaAlta([FromBody][Required] DarBajaAltaUsuarioRequest request)
        {
            try
            {
                var input = this._mapper.Map<DarBajaAltaUsuarioRequest, DarBajaAltaUsuarioInput>(request);
                var output = this._useCase.Execute(input);
                string mensaje = output.FechaBaja == null
                    ? "Usuario dado de alta correctamente."
                    : "Usuario dado de baja correctamente.";

                return Ok(new
                {
                    status = "success",
                    datos = output,
                    mensaje = mensaje
                });
            }
            catch (ArgumentInputException ex)
            {
                return BadRequest(new { status = "error", mensaje = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { status = "error", mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", mensaje = "Error interno al dar de baja/alta usuario." });
            }
        }

    }
}

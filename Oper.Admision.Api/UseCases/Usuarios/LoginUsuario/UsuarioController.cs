using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Usuarios.Login;
using Oper.Admision.Infrastructure.Seguridad;
using System.ComponentModel.DataAnnotations;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using Oper.Admision.Application.UseCases.Usuarios.CambiarPassword;

namespace Oper.Admision.Api.UseCases.Usuarios.LoginUsuario
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly CambiarPasswordUsuarioUseCase _cambiarPasswordUseCase;

        public UsuarioController(CambiarPasswordUsuarioUseCase cambiarPasswordUseCase)
        {
            _cambiarPasswordUseCase = cambiarPasswordUseCase;
        }

        [HttpPut("cambiar-password")]
        public IActionResult CambiarPassword([FromBody] CambiarPasswordUsuarioInput input)
        {
            try
            {
                bool exito = _cambiarPasswordUseCase.Execute(input);

                if (exito)
                {
                    return Ok(new { mensaje = "Contraseña cambiada correctamente" });
                }
                else
                {
                    return BadRequest(new { mensaje = "La nueva contraseña es igual a la actual." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
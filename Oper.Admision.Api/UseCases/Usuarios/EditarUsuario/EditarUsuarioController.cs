using AutoMapper;
using Oper.Admision.Application.UseCases.Rol.GetTodos;
using Oper.Admision.Application.UseCases.Usuarios.Editar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UseCases.Usuarios.EditarUsuario
{
    [Route("api/usuarios")]
    [ApiController]
    
    public class EditarUsuarioController : ControllerBase
    {
        private readonly EditarUsuarioUseCase _useCase;
        private readonly IMapper _mapper;

        public EditarUsuarioController(EditarUsuarioUseCase useCase, IMapper mapper )
        {
            this._useCase =useCase;
            this._mapper = mapper;
        }

        [HttpPut("Editar")]
        public IActionResult Editar ([Required]  EditarUsuarioRequest request)
        {
            var input = this._mapper.Map<EditarUsuarioRequest, EditarUsuarioInput>(request);
            var output = this._useCase.Execute(input);

            return Ok(output);
        }
    }
}

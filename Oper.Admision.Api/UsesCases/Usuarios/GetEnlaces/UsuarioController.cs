using AutoMapper;
using Oper.Admision.Application.UseCases.Rol.GetEnlaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Oper.Admision.Api.UseCases.Usuarios.GetEnlaces
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly GetEnlacesUseCase _useCase;
        private readonly IMapper _mapper;
        private readonly IUsuarioApi _usuarioApi;

        public UsuarioController(GetEnlacesUseCase useCase, IMapper mapper, IUsuarioApi usuarioApi)
        {
            this._useCase = useCase;
            this._mapper = mapper;
            this._usuarioApi = usuarioApi;
        }

        [HttpGet("GetEnlaces")]
        public IActionResult GetTodos()
        {
            return Ok(this._useCase.Execute(new GetEnlacesInput() { UsuarioId=this._usuarioApi.UsuarioId}));
        }
    }
}

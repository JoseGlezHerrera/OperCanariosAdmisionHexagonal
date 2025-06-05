using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Oper.Admision.Api.UseCases.Usuarios.GetTodosUsuario
{
    [Route("api/usuarios")]
    [ApiController]
    [Authorize]
    public class GetTodosUsuarioController : ControllerBase
    {
        private readonly GetTodosUsuarioUseCase _useCase;
        private readonly IMapper _mapper;

        public GetTodosUsuarioController(GetTodosUsuarioUseCase useCase, IMapper mapper)
        {
            this._useCase = useCase;
            this._mapper = mapper;
        }

        [HttpGet("todos")]
        public async Task<IActionResult> GetTodos()
        {
            var input = new GetTodosUsuarioInput();
            var usuarios = await _useCase.Execute(input);
            var response = _mapper.Map<List<GetTodosUsuarioResponse>>(usuarios);
            return Ok(response);
        }
    }
}

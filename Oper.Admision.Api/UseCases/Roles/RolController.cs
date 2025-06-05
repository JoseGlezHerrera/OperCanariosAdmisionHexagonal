using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Rol.GetTodos;

namespace Oper.Admision.Api.UseCases.Rol
{
    [Route("api/roles")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly GetTodosUseCase _useCase;

        public RolController(GetTodosUseCase useCase)
        {
            this._useCase = useCase;
        }

        [HttpGet("GetTodos")]
        public IActionResult GetAll()
        {
            var output = this._useCase.Execute();
            return Ok(output);
        }
    }
}

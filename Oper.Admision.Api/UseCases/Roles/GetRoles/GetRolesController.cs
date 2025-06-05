using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Rol.GetRoles;

namespace Oper.Admision.Api.UseCases.Roles.GetRoles
{
    [Route("api/roles")]
    [ApiController]
    public class GetRolesController : ControllerBase
    {
        private readonly GetRolesUseCase _useCase;
        private readonly IMapper _mapper;
        public GetRolesController(GetRolesUseCase useCase, IMapper mapper)
        {
            _useCase = useCase;
            _mapper = mapper;
        }
        [HttpGet("GetTodos")]
        public IActionResult GetTodos()
        {
            var input = new GetRolesInput();
            var output = _useCase.Execute(input);
            var response = _mapper.Map<List<GetRolesOutput>>(output);
            return Ok(response);
        }
    }
}

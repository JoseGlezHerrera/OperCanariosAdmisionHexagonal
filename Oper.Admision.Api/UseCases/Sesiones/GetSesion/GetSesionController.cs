using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Sesiones.GetSesion;

namespace Oper.Admision.Api.UseCases.Sesiones.GetSesion
{
    [Route("api/sesiones")]
    [ApiController]
    public class GetSesionController : ControllerBase
    {
        private readonly GetSesionUseCase _useCase;
        private readonly IMapper _mapper;

        public GetSesionController(GetSesionUseCase useCase, IMapper mapper)
        {
            _useCase = useCase;
            _mapper = mapper;
        }

        [HttpGet("GetSesion")]
        public async Task<IActionResult> GetSesion()
        {
            var input = new GetSesionInput();
            var output = await _useCase.Execute(input);
            return Ok(output);
        }
    }
}
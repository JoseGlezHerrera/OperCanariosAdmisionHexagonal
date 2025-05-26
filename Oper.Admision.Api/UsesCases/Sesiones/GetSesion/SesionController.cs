using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Sesiones.GetSesion;

namespace Oper.Admision.Api.UsesCases.Sesiones.GetSesion
{
    [Route("api/[controller]")]
    [ApiController]

    public class SesionController : ControllerBase
    {
        private readonly GetSesionUseCase _useCase;
        private readonly IMapper _mapper;

        public SesionController(GetSesionUseCase useCase, IMapper mapper)
        {
            this._useCase = useCase;
            this._mapper = mapper;
        }

        [HttpGet("GetVisitas")]

        public IActionResult GetSesion()
        {
            return Ok(this._useCase.Execute());
        }
    }
}

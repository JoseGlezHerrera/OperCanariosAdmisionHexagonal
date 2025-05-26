using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Socios.EditarSocio;
using Oper.Admision.Application.UseCases.Socios.EditarUsuario;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UsesCases.Socios.EditarSocio
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly EditarSocioUseCase _useCase;
        private readonly IMapper _mapper;

        public SocioController(EditarSocioUseCase useCase, IMapper mapper)
        {
            this._useCase = useCase;
            this._mapper = mapper;
        }

        [HttpPost("Editar")]
        public IActionResult Editar([Required] EditarSocioRequest request)
        {
            var input = this._mapper.Map<EditarSocioRequest, EditarSocioInput>(request);
            var output = this._useCase.Execute(input);
            return Ok(output);
        }
    }
}
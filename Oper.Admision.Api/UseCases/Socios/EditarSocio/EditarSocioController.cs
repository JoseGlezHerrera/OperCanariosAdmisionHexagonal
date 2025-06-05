using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Socios.EditarSocio;
using Oper.Admision.Application.UseCases.Socios.EditarUsuario;
using System.ComponentModel.DataAnnotations;

namespace Oper.Admision.Api.UseCases.Socios.EditarSocio
{
    [Route("api/socios")]
    [ApiController]
    public class EditarSocioController : ControllerBase
    {
        private readonly EditarSocioUseCase _useCase;
        private readonly IMapper _mapper;

        public EditarSocioController(EditarSocioUseCase useCase, IMapper mapper)
        {
            this._useCase = useCase;
            this._mapper = mapper;
        }

        [HttpPut("editar")]
        public IActionResult Editar([Required] EditarSocioRequest request)
        {
            var input = _mapper.Map<EditarSocioRequest, EditarSocioInput>(request);
            var output = this._useCase.Execute(input);
            var response = _mapper.Map<EditarSocioResponse>(output);
            return Ok(response);
        }
    }
}
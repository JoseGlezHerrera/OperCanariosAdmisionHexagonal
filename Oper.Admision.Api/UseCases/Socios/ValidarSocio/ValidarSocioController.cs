using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Socios.ValidarSocio;

namespace Oper.Admision.Api.UseCases.Socios.ValidarSocio
{
    [ApiController]
    [Route("api/socios/validar")]
    public class ValidarSocioController : ControllerBase
    {
        private readonly ValidarSocioUseCase _useCase;
        public ValidarSocioController(ValidarSocioUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpPost]
        public ActionResult<ValidarSocioResponse> Post (ValidarSocioRequest request)
        {
            var resultado = _useCase.Execute(request.Dni, request.Nombre, request.SocioId);
            return Ok(new ValidarSocioResponse
            {
                EsValido = resultado.esValido,
                Mensaje = resultado.mensaje
            });
        }
    }
}

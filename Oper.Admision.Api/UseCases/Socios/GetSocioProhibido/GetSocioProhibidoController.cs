using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Socios.GetSocioProhibido;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Socios.GetSocioProhibido
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetSocioProhibidoController : ControllerBase
    {
        private readonly GetSocioProhibidoUseCase _useCase;

        public GetSocioProhibidoController(GetSocioProhibidoUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        public ActionResult<List<GetSocioProhibidoResponse>> Get()
        {
            var lista = _useCase.Execute();
            var response = lista.Select(s => new GetSocioProhibidoResponse
            {
                Id = s.id_socio,
                Dni = s.dni,
                Nombre = $"{s.nombre} {s.apel1} {s.apel2}"

            }).ToList();
            return Ok(response);
        }
    }
}
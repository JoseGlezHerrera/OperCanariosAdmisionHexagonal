using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.RegistrarVisita;

namespace Oper.Admision.Api.UseCases.Visitas.RegistrarVisita
{
    [ApiController]
    [Route("api/[controller]")] 
    public class RegistrarVisitaController : ControllerBase
    {
        private readonly RegistrarVisitaUseCase _useCase;
        public RegistrarVisitaController(RegistrarVisitaUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpPost]
        public ActionResult <RegistrarVisitaResponse> Post (RegistrarVisitaRequest request)
        {
            var resultado = _useCase.Execute(request.SocioId, request.SesionId);
            return Ok(new RegistrarVisitaResponse
            {
                Registrado = resultado.registrado,
                FechaHora = resultado.fecha,
                Mensaje = resultado.mensaje
            });
        }
    }
}

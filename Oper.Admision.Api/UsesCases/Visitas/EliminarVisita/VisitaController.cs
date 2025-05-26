using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.EliminarVisita;

namespace Oper.Admision.Api.UsesCases.Visitas.EliminarVisita
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class VisitaController : ControllerBase
    {
        private readonly EliminarVisitaUseCase _useCase;

        public VisitaController(EliminarVisitaUseCase useCase)
        {
            this._useCase = useCase;
        }

        [HttpDelete("{id_visita}")]
        public IActionResult Eliminar(int id_visita)
        {
            var input = new EliminarVisitaInput() { id_visita = id_visita };
            this._useCase.Execute(input);
            return Ok(true);
        }
    }
}

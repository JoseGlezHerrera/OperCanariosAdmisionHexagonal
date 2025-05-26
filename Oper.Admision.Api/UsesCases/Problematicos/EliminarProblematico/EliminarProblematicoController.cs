using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Problematico.EliminarProblematico;

namespace Oper.Admision.Api.UsesCases.Problematicos.EliminarProblematico
{
    [Route("api/problematicos")]
    [ApiController]
    [Authorize]
    public class EliminarProblematicoController : ControllerBase
    {
        private readonly EliminarProblematicoUseCase _useCase;
        public EliminarProblematicoController(EliminarProblematicoUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id )
        {
            var input = new EliminarProblematicoInput(id);
            var eliminado = await _useCase.Handle(input);
            return eliminado ? NoContent() : NotFound();
        }
    }
}

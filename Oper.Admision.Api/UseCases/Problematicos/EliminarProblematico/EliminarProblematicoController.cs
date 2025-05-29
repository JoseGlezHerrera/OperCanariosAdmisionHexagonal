using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Problematico.EliminarProblematico;
using Oper.Admision.Application.UseCases.Visita.EliminarVisita;

namespace Oper.Admision.Api.UseCases.Problematicos.EliminarProblematico;

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
    public async Task<IActionResult> Eliminar(int id)
    {
        var input = new EliminarProblematicoInput(id);
        var result = await _useCase.Handle(input);

        if (!result)
            return NotFound($"No se encontró un problemático con el id {id}.");

        return Ok(new { message = "Problemático eliminado correctamente." });
    }
}

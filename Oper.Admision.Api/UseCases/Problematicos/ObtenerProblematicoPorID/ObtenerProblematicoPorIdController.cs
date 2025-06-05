using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Api.UseCases.Problematicos.ObtenerProblematicoID;
namespace Oper.Admision.Api.UseCases.Problematicos.ObtenerProblematicoID;

[Route("api/problematicos/obtener-por-id")]
[ApiController]
[Authorize]
public class ObtenerProblematicoPorIDController : ControllerBase
{
    private readonly ObtenerProblematicoPorIdUseCase _useCase;

    public ObtenerProblematicoPorIDController(ObtenerProblematicoPorIdUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var input = new ObtenerProblematicoPorIdInput(id);
        var result = await _useCase.Handle(input);
        return result is not null ? Ok(result) : NotFound();
    }
}
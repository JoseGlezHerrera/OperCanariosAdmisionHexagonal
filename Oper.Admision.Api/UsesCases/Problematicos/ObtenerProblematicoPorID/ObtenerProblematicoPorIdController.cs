using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Api.UsesCases.Problematicos.ObtenerProblematicoID;
namespace Oper.Admision.Api.UseCases.Problematicos.ObtenerProblematicoID;

[Route("api/problematicos")]
[ApiController]
[Authorize]
public class ObtenerProblematicoPorIdController : ControllerBase
{
    private readonly ObtenerProblematicoPorIdUseCase _useCase;

    public ObtenerProblematicoPorIdController(ObtenerProblematicoPorIdUseCase useCase)
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
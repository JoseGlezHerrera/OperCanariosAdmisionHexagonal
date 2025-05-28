using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Problematico.FiltrarProblematicoPorTipo;

namespace Oper.Admision.Api.UseCases.Problematicos.FiltrarProblematicoPorTipo;

[Route("api/problematicos")]
[ApiController]
[Authorize]
public class FiltrarProblematicoPorTipoController : ControllerBase
{
    private readonly FiltrarProblematicoPorTipoUseCase _useCase;
    public FiltrarProblematicoPorTipoController(FiltrarProblematicoPorTipoUseCase useCase)
    {
        _useCase = useCase;
    }
    [HttpGet("filtrar")]
    public async Task<IActionResult> FiltrarPorTipo([FromQuery] string tipo)
    {
        var input = new FiltrarProblematicoPorTipoInput(tipo);
        var resultado = await _useCase.Handle(input);
        return Ok(resultado);
    }
}
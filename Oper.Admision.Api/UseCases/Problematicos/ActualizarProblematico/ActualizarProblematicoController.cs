using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Api.UseCases.Problematicos.ActualizarProblematico;
using Oper.Admision.Application.UseCases.Problematico.ActualizarProblematico;

namespace Oper.Admision.Api.UseCases.Problematicos.ActualizarProblematico;

[Route("api/problematicos")]
[ApiController]
[Authorize]
public class ActualizarProblematicoController : ControllerBase
{
    private readonly ActualizarProblematicoUseCase _useCase;
    private readonly IMapper _mapper;

    public ActualizarProblematicoController(ActualizarProblematicoUseCase useCase, IMapper mapper)
    {
        _useCase = useCase;
        _mapper = mapper;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarProblematicoRequest request)
    {
        var input = _mapper.Map<ActualizarProblematicoInput>(request) with { Id = id };
        var result = await _useCase.Handle(input);
        return result ? NoContent() : NotFound();
    }
}
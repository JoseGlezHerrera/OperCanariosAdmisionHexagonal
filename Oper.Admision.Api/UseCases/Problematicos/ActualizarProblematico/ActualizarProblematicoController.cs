using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Api.UseCases.Problematicos.ActualizarProblematico;
using Oper.Admision.Application.UseCases.Problematico.ActualizarProblematico;
using Oper.Admision.Domain.IRepositories;

namespace Oper.Admision.Api.UseCases.Problematicos.ActualizarProblematico;

[Route("api/problematicos/actualizar")]
[ApiController]
[Authorize]
public class ActualizarProblematicoController : ControllerBase
{
    private readonly ActualizarProblematicoUseCase _useCase;
    private readonly IMapper _mapper;
    private readonly IProblematicoRepository _repository;

    public ActualizarProblematicoController(ActualizarProblematicoUseCase useCase,IMapper mapper,IProblematicoRepository repository)
    {
        _useCase = useCase;
        _mapper = mapper;
        _repository = repository;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarProblematicoRequest request)
    {
        var input = _mapper.Map<ActualizarProblematicoInput>(request) with { Id = id };
        var result = await _useCase.Execute(input);

        if (!result)
            return NotFound();

        var actualizado = await _repository.GetByIdAsync(id);
        return Ok(actualizado);
    }

}
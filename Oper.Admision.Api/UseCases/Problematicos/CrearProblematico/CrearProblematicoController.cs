using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Api.UseCases.Problematicos;
using Oper.Admision.Application.UseCases.Problematicos.CrearProblematico;

namespace Oper.Admision.Api.UseCases.Problematicos.CrearProblematico;

[Route("api/problematicos")]
[ApiController]
[Authorize]
public class CrearProblematicoController : ControllerBase
{
    private readonly CrearProblematicoUseCase _useCase;
    private readonly IMapper _mapper;

    public CrearProblematicoController(CrearProblematicoUseCase useCase, IMapper mapper)
    {
        _useCase = useCase;
        _mapper = mapper;
    }

    [HttpPost("InsertarProblematico")]
    public async Task<IActionResult> Insertar([FromBody] CrearProblematicoRequest request)
    {
        var input = _mapper.Map<CrearProblematicoRequest, CrearProblematicoInput>(request);
        var resultado = await _useCase.Execute(input);
        var response = _mapper.Map<CrearProblematicoResponse>(resultado);
        return Ok(response);
    }
}
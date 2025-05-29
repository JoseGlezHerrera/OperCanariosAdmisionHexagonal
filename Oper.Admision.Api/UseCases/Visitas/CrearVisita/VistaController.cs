using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Application.UseCases.Visitas.CrearVisita;

namespace Oper.Admision.Api.UseCases.Visitas.CrearVisita;

[Route("api/visitas")]
[ApiController]
public class CrearVisitaController : ControllerBase
{
    private readonly CrearVisitaUseCase _useCase;
    private readonly IMapper _mapper;

    public CrearVisitaController(CrearVisitaUseCase useCase, IMapper mapper)
    {
        _useCase = useCase;
        _mapper = mapper;
    }

    [HttpPost("Crear")]
    public async Task<IActionResult> Crear(CrearVisitaInput input)
    {
        var outputCore = await _useCase.EjecutarAsync(input);
        var response = _mapper.Map<CrearVisitaResponse>(outputCore);
        return Ok(response);
    }
}
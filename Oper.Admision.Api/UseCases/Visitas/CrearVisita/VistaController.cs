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

    [HttpPost]
    public async Task<ActionResult<CrearVisitaResponse>> Crear([FromBody] CrearVisitaInput input)
    {
        var visita = await _useCase.EjecutarAsync(input);
        var response = _mapper.Map<CrearVisitaResponse>(visita);
        return CreatedAtAction(nameof(Crear), new { id = response.Id }, response);
    }
}
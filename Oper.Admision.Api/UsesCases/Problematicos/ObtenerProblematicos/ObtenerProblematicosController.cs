using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Problematicos.ObtenerProblematicos;

[Route("api/problematicos")]
[ApiController]
[Authorize]
public class GetProblematicosController : ControllerBase
{
    private readonly IProblematicoRepository _repo;

    public GetProblematicosController(IProblematicoRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("GetProblematicos")]
    public async Task<IActionResult> GetProblematicos(int? id_sesion)
    {
        var resultado = await _repo.ObtenerProblematicosAsync(id_sesion);
        return Ok(resultado);
    }

}
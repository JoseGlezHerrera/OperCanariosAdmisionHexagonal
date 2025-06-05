using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Problematicos.ObtenerProblematicos;

[Route("api/problematicos")]
[ApiController]
[Authorize]
public class ObtenerProblematicosController : ControllerBase
{
    private readonly IProblematicoRepository _repo;

    public ObtenerProblematicosController(IProblematicoRepository repo)
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
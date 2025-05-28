namespace Oper.Admision.Api.UseCases.Visitas.CrearVisita;

public class CrearVisitaResponse
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string? Motivo { get; set; }
    public int SocioId { get; set; }
}

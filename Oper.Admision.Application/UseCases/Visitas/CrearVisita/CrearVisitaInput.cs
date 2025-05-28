namespace Oper.Admision.Application.UseCases.Visitas.CrearVisita;

public class CrearVisitaInput
{
    public int SocioId { get; set; }
    public DateTime Fecha { get; set; }
    public string? Motivo { get; set; }
    public int IdSesion { get; set; }
    public int IdSede { get; set; }
}
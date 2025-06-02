namespace Oper.Admision.Api.UseCases.Visitas.RegistrarVisita
{
    public class RegistrarVisitaResponse
    {
        public bool Registrado { get; set; }
        public DateTime FechaHora { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }
}

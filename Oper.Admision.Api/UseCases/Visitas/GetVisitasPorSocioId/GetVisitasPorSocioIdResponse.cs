namespace Oper.Admision.Api.UseCases.Visitas.GetVisitasPorSocioId
{
    public class GetVisitasPorSocioIdResponse
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Observaciones { get; set; }
        public int SocioId { get; set; }
        public string? NombreSocio { get; set; }
        public bool Activa { get; set; }
    }
}
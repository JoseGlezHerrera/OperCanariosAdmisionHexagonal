namespace Oper.Admision.Api.UsesCases.Problematicos.ObtenerProblematicoID
{
    public class ObtenerProblematicoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; } //1: gobcan, 2: Prohibida Entrada, 3: conflictivo
        public string Observaciones { get; set; }
    }
}

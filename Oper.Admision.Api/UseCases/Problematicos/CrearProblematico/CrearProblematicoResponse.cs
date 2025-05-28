namespace Oper.Admision.Api.UseCases.Problematicos.CrearProblematico
{
    public class CrearProblematicoResponse
    {
          
        public DateTime FechaCreacion { get; set; }
        public string Dni { get; set; }
        public string Regla { get; set; }
        public string Comentario { get; set; }
        public int TipoProblematico { get; set; } //1: gobcan, 2: Prohibida Entrada, 3: conflictivo

    }
}

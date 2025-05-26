namespace Oper.Admision.Api.UsesCases.Problematicos
{
    public class CrearProblematicoRequest
    {
        public string Dni { get; set; }
        public string Regla { get; set; }
        public string Comentario { get; set; }
        public int TipoProblematico { get; set; } // 1: gobcan, 2: Prohibida Entrada, 3: conflictivo
        public int IdSede { get; set; }
        public int IdSesion { get; set; }
        public int IdSocio { get; set; }
    }
}

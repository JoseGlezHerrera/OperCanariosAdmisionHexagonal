using System;

namespace Oper.Admision.Domain.Models
{
    public class ProblematicoVista
    {
        public string Regla { get; set; }
        public string Comentario { get; set; }
        public int TipoProblematico { get; set; }
        public string Dni { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}

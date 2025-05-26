using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Problematico.CrearProblematico
{
    public class CrearProblematicoInput
    {
        public string Dni { get; set; }
        public string Regla { get; set; }
        public string Comentario { get; set; }
        public int TipoProblematico { get; set; } // 1: gobcan, 2: Prohibida Entrada, 3: conflictivo
        public int IdSede { get; set; }
        public int IdSesion { get; set; }
        public int IdSocio { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}

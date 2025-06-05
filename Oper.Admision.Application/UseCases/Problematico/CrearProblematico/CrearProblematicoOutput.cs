using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Problematicos.CrearProblematico
{
    public class CrearProblematicoOutput
    {
        public int IdSocio { get; set; }
        public int IdSesion { get; set; }
        public int IdSede { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Regla { get; set; }
        public string Comentario { get; set; }
        public bool Visible { get; set; }
        public bool Conflictivo { get; set; }
        public bool ProhibidaEntrada { get; set; }
        public string? Dni { get; set; }
        public int TipoProblematico { get; set; }
        public bool Gobcan { get; set; }
    }
}
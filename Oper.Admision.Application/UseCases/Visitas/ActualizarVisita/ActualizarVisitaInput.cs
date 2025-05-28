using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.ActualizarVisita
{
    public class ActualizarVisitaInput
    {
        public int IdVisita { get; set; }
        public DateTime fecha { get; set; }
        public int IdSesion { get; set; }
        public string Motivo { get; set; } = string.Empty;
    }
}

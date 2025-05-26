using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.CrearVisita
{
    public class CrearVisitaOutput
    {
        public int id_visita { get; set; }

        public int id_socio { get; set; }
        public int? id_sesion { get; set; }
        public int? id_sede { get; set; }
        public DateTime fecha_hora { get; set; }

        public CrearVisitaOutput()
        {
            this.fecha_hora = DateTime.Now;
        }
    }
}

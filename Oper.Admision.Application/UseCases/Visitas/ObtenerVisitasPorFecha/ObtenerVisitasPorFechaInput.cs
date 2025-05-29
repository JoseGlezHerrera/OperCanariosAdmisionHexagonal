using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.ObtenerVisitasPorFecha
{
    public class ObtenerVisitasPorFechaInput
    {
        public DateTime Fecha { get; set; }
        public ObtenerVisitasPorFechaInput(DateTime fecha)
        {
            Fecha = fecha.Date;
        }
    }
}
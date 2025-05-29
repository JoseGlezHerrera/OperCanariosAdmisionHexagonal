using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.ObtenerVisitasPorFecha
{
    public class ObtenerVisitasPorFechaResponse
    {
        public int Id { get; set; }
        public int IdSocio { get; set; }
        public DateTime Fecha { get; set; }
        public string? Motivo { get; set; }
    }
}
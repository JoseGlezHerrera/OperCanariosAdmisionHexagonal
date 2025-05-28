using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.ObtenerVisitaPorId
{
    public class ObtenerVisitaPorIdResponse
    {
        public int Id { get; set; }
        public int id_socio { get; set; }
        public DateTime fecha_hora { get; set; }
        public string? motivo { get; set; }
    }
}

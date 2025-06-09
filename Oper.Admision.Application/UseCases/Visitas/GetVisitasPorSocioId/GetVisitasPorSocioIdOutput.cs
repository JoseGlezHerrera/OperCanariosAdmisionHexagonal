using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.GetVisitasPorSocioId
{
    public class GetVisitasPorSocioIdOutput
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Observaciones { get; set; }
        public int SocioId { get; set; }
        public string? NombreSocio { get; set; }
        public bool Activa { get; set; }
    }
}

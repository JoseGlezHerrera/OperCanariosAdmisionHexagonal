using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.ListarVisitasPorSocio
{
    public class ListarVisitasPorSocioInput
    {
        public int SocioId { get; }
        public ListarVisitasPorSocioInput(int socioId)
        {
            if (socioId <= 0)
            {
                throw new ArgumentException("El ID del socio debe ser un número positivo.", nameof(socioId));
            }
            SocioId = socioId;
        }
    }
}

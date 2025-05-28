using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.ObtenerVisitaPorId
{
    public class ObtenerVisitaPorIdInput
    {
        public int Id { get; set; }
        public ObtenerVisitaPorIdInput(int id)
        {
            Id = id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.ObtenerSocioPorId
{
    public class ObtenerSocioPorIdInput
    {
        public int Id { get; }
        public ObtenerSocioPorIdInput(int id)
        {
            Id = id;
        }
    }
}

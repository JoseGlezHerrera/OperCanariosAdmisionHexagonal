using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.EliminarSocio
{
    public class EliminarSocioInput
    {
        public int Id { get; set; }

        public EliminarSocioInput(int id)
        {
            Id = id;
        }

    }
}

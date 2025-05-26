using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.CrearSocio
{
    public class CrearSocioInput
    {
        public string nombre { get; set; }
        public string apel1 { get; set; }
        public string apel2 { get; set; }
        public string dni { get; set; }
        public int id_socio { get; set; }
        public string calle { get; set; }
        public string telefono { get; set; }
        public string comentario { get; set; }
        public string foto { get; set; }


    }
}

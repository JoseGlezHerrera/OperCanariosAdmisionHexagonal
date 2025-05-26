using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.GetSocio
{
    public class GetSocioOutput
    {
        public int id_socio { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apel1 { get; set; }
        public string apel2 { get; set; }
        public string calle { get; set; }
        public string telefono { get; set; }
        public string comentario { get; set; }
        public string foto { get; set; }
        public DateTime? fecha_alta { get; set; }
        public DateTime? fecha_baja { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.Models
{
    [Table ("visitas")]
    public class Visita
    {
        [Key]
        public int id_visita { get; set; }
        public int id_sesion { get; set; }
        public Nullable <int> id_sede { get;set; }
        public int id_socio { get; set; }
        public System.DateTime fecha_hora { get; set; }      
        public virtual Sesion sesion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.Models
{
    [Table ("sesiones")]
    public class Sesion
    {
        public Sesion()
        {
            this.visita = new HashSet<Visita>();
        }
        [Key]
        public int id_sesion { get; set; }
        public System.DateTime fecha_inicio { get; set; }

        public int hombres { get; set; }
        public int mujeres { get; set; }
        public int nuevos { get; set; }
        public int habituales { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public int id_sede { get; set; }
        public virtual Sede sede { get; set; }
       public virtual ICollection<Visita> visita { get; set; }
        public DateTime fecha_hora { get; set; }
    }
}

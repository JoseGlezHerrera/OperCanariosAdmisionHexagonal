using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.Models
{
    [Table("sedes")]
    public class Sede
    {
        public Sede()
        { 
            this.sesion = new HashSet<Sesion>();
        }
        [Key]
        public int id_sede { get; set; }
        public int id_establecimiento { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<Sesion> sesion { get; set; }
    }
}

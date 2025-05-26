using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.Models
{
    [Table("problematicos")]
    public partial class Problematico
    {
        [Key]
        public int id_problematicos { get; set; }
        public int id_sede { get; set; }
        public int id_sesion { get; set; }
        public string regla { get; set; }
        public bool conflictivo { get; set; }
        public bool prohibida_entrada { get; set; }
        public bool gobcan { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public Nullable<int> id_socio { get; set; }
        public string comentario { get; set; }
        public bool visible { get; set; }
        public enum TipoProblematicoEnum
        {
            Conflictivo = 1,
            ProhibidaEntrada = 2,
            Gobcan = 3
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.Models
{
    [Table("cumples")]
    public class Cumples
    {
        [Key]
        public int id_cumple { get; set; }
        public Nullable<int> id_sesion { get; set; }
        public Nullable<int> id_socio { get; set; }
        public Nullable<int> id_sede { get; set; }
        public Nullable<System.DateTime> fecha_cre_mod { get; set; }
        public Nullable<int> anio { get; set; }

    }
}

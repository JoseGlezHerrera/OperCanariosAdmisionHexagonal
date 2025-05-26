using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.Models
{
    [Table("reglasConflictivos")]
    public class ReglaConflictivo
    {
        [Key]
        public int id_regla { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apel1 { get; set; }
        public string apel2 { get; set; }
        public Nullable <System.DateTime> fecha_nacimiento { get; set; }
        public Nullable<int> id_municipio { get; set; }
        public Nullable<int> id_provincia { get; set; }
        public string comentario { get; set; }
        public Nullable<bool> sexo { get; set; }
        public bool eliminada { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.Models
{
    [Table("socios")]
    public class Socio
    {
        [Key]
        public int id_socio { get; set; }
        public string? dni { get; set; }
        public string? nombre { get; set; }
        public string? apel1 { get; set; }
        public string? apel2 { get; set; }
        public System.DateTime fecha_nacimiento { get; set; }
        public Nullable<bool> sexo { get; set; }
        public Nullable<int> id_municipio { get; set; }
        public Nullable<int> id_provincia { get; set; }
        public string? calle { get; set; }
        public Nullable<int> cp { get; set; }
        public string? telefono { get; set; }
        public Nullable<System.DateTime> fecha_alta { get; set; }
        public Nullable<System.DateTime> fecha_baja { get; set; }
        public string? comentario { get; set; }
        public Nullable<int> puntos { get; set; }
        public Nullable<int> total_visitas { get; set; }
        public string? foto { get; set; }
        public Nullable<int> id_login { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
        public Nullable<bool> prohibida_entrada { get; set; }
        public int id_pais { get; set; }

        [NotMapped]
        public DateTime? FechaUltimaVisita { get; set; }

        public Socio() { }
    }
}

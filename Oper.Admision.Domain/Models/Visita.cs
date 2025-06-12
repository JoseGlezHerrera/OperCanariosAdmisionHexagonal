using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oper.Admision.Domain.Models
{
    [Table("visitas")]
    public class Visita
    {
        [Key]
        public int id_visita { get; set; }
        [Column("id_sesion")]
        [ForeignKey(nameof(Sesion))]
        public int id_sesion { get; set; }
        public int? id_sede { get; set; }
        public int id_socio { get; set; }
        public DateTime fecha_hora { get; set; }
        public string? motivo { get; set; }
        public virtual Sesion Sesion { get; set; }
        [ForeignKey(nameof(id_socio))]
        public virtual Socio Socio { get; set; }

    }
}
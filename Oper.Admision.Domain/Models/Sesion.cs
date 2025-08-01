﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oper.Admision.Domain.Models
{
    [Table("sesiones")]
    public class Sesion
    {
        [Key]
        public int id_sesion { get; set; }

        public DateTime fecha_inicio { get; set; }
        public int hombres { get; set; }
        public int mujeres { get; set; }
        public int nuevos { get; set; }
        public int habituales { get; set; }
        public DateTime fecha_fin { get; set; }

        public int id_sede { get; set; }

        [ForeignKey("id_sede")]
        public virtual Sede sede { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Sesiones.CrearSesion
{
    public class CrearSesionOutput
    {
        public int id_sesion { get; set; }
        public DateTime fecha_inicio { get; set; }

        public int hombres { get; set; }
        public int mujeres { get; set; }
        public int nuevos { get; set; }
        public int habituales { get; set; }
        public DateTime fecha_fin { get; set; }
        public int id_sede { get; set; }
        // public virtual Sede sede { get; set; }
    }
}

namespace Oper.Admision.Api.UsesCases.Sesiones.CrearSesion
{
    internal class CrearSesionResponse
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

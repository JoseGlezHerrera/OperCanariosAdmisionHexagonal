namespace Oper.Admision.Api.UsesCases.Socios.EditarSocio
{
    internal class EditarSocioResponse
    {
        public int id_socio { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apel1 { get; set; }
        public string apel2 { get; set; }
        public Nullable<System.DateTime> fecha_alta { get; set; }
        public Nullable<System.DateTime> fecha_baja { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
    }
}

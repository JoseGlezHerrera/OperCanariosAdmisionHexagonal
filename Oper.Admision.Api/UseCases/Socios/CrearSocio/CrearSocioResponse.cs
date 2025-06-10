namespace Oper.Admision.Api.UseCases.Socios.CrearSocio
{
    internal class CrearSocioResponse
    {
        public string nombre { get; set; }
        public string apel1 { get; set; }
        public string apel2 { get; set; }
        public string dni { get; set; }
        public int id_socio { get; set; }
        public string calle { get; set; }
        public string telefono { get; set; }
        public string comentario { get; set; }
        public string sexo { get; set; }
        public DateTime? fecha_modificacion { get; set; }

    }
}

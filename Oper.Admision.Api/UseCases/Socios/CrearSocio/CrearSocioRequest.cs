namespace Oper.Admision.Api.UseCases.Socios.CrearSocio
{
    public class CrearSocioRequest
    {
        public string nombre { get; set; }
        public string apel1 { get; set; }
        public string apel2 { get; set; }
        public string dni { get; set; }
        public string calle { get; set; }
        public string telefono { get; set; }
        public string comentario { get; set; }
        public DateTime? fecha_nacimiento { get; set; }

    }
}

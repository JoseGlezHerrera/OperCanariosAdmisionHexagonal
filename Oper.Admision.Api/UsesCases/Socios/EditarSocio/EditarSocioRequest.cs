namespace Oper.Admision.Api.UsesCases.Socios.EditarSocio
{
    public class EditarSocioRequest
    {
        public int id_socio { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apel1 { get; set; }
        public string apel2 { get; set; }
    }
}

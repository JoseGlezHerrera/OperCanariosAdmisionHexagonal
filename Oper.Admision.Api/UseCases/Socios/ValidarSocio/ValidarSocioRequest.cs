namespace Oper.Admision.Api.UseCases.Socios.ValidarSocio
{
    public class ValidarSocioRequest
    {
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int? SocioId { get; set; }
    }
}

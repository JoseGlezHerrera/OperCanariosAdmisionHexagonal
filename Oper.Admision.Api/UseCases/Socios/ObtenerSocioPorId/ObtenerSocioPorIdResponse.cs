namespace Oper.Admision.Api.UseCases.Socios.ObtenerSocioPorId
{
    public class ObtenerSocioPorIdResponse
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
    }
}

namespace Oper.Admision.Api.UseCases.Socios.ObtenerCumpleañeros;

public class ObtenerCumpleañerosResponse
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
}
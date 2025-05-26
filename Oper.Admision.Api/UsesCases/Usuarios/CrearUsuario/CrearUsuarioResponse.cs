namespace Oper.Admision.Api.UseCases.Usuarios.CrearUsuario
{
    internal class CrearUsuarioResponse
    {
        public int UsuarioId { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int RolId { get; set; }
    }
}
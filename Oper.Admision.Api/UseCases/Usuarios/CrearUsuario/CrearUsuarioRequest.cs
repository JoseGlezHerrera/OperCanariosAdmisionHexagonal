namespace Oper.Admision.Api.UseCases.Usuarios.CrearUsuario
{
    public class CrearUsuarioRequest
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
        public string Password { get; set; }
    }
}
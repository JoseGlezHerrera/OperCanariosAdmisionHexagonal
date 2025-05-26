namespace Oper.Admision.Api.UseCases.Usuarios.EditarUsuario
{
    public class EditarUsuarioRequest
    {
        public int UsuarioId { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
    }
}
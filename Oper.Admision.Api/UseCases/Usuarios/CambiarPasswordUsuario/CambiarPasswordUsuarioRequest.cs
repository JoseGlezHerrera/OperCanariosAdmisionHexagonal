namespace Oper.Admision.Api.UseCases.Usuarios.CambiarPasswordUsuario
{
    public class CambiarPasswordUsuarioRequest
    {
        public int UsuarioId { get; set; }
        public string Password { get; set; }
    }
}
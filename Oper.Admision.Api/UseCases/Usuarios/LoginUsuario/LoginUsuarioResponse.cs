namespace Oper.Admision.Api.UseCases.Usuarios.LoginUsuario
{
    public class LoginUsuarioResponse
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }
        public int RolId { get; set; }
        public string Token { get; set; }

        public bool Succeeded { get; set; }
        public string Mensaje { get; set; }
        public List<string> Errores { get; set; }
    }
}
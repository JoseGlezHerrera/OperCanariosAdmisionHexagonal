namespace Oper.Admision.Api.UseCases.Usuarios.LoginUsuario
{
    internal class LoginUsuarioResponse
    {
        public string Nombre { get; set; }
        public int RolId { get; set; }
        public string Alias { get; set; }

        public string Token { get; set; }
    }
}
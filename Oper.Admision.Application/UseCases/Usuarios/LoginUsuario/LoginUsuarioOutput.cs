
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Application.UseCases.Usuarios.Login
{
    public class LoginUsuarioOutput
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }
        public int RolId { get; set; }
        public bool Succeeded { get; internal set; }
        public string Mensaje { get; internal set; }
        public List<string> Errores { get; internal set; }
        public string? Token { get; set; }
        public Usuario Usuario { get; set; }
    }
}
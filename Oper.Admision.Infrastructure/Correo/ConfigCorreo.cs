
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Infrastructure.Correo
{
    public class ConfigCorreo : IConfigCorreo
    {
        public string Servidor { get; set; }
        public int Puerto { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Destinatarios { get; set; }
    }
}

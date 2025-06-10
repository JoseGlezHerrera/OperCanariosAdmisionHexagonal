using System.Security.Cryptography;

namespace Oper.Admision.Domain.Seguridad
{
    public static class GeneradorClaves
    {
        public static string Token(int longitud)
        {
            return Guid.NewGuid().ToString("n").Substring(0, longitud);
        }
    }
}

using System.Security.Cryptography;

namespace Oper.Admision.Domain.Seguridad
{
    public static class GeneradorClaves
    {
        public static string Token(int longitud)
        {
            return Guid.NewGuid().ToString("n").Substring(0, longitud);

            //byte[] randomBytes = new Byte[64];
            //var randomGenerator = RandomNumberGenerator.Create();
            //randomGenerator.GetBytes(randomBytes);

            ////using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            ////{
            ////    rng.GetBytes(randomBytes);
            ////}
            //SHA256Cng ShaHashFunction = new SHA256Cng();
            //byte[] hashedBytes = ShaHashFunction.ComputeHash(randomBytes);
            //string randomString = string.Empty;
            //foreach (byte b in hashedBytes)
            //{
            //    randomString += string.Format("{0:x2}", b);
            //}
            //return randomString.Substring(randomString.Length - longitud, longitud);
        }
    }
}

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Oper.Admision.Api.Seguridad
{
    public class TokenJWT
    {

        public static string GenerarTokenJWT(int usuarioId, JWT jwt)
        {
            if (jwt == null)
                throw new Exception("JWT Configuration is null.");

            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwt.ClaveSecreta)
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //            
            var _Claims = new List<Claim>();
            _Claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            _Claims.Add(new Claim("UsuarioId", usuarioId.ToString()));

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: jwt.Issuer,
                    audience: jwt.Audience,
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Expira a la 24 horas.
                    expires: DateTime.UtcNow.AddMinutes(jwt.TimeoutMinutos)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}

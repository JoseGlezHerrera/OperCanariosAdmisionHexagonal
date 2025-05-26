using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Oper.Admision.Application.Wrappers;
using Oper.Admision.Api.Seguridad;
using System.Text.Json;

namespace Oper.Admision.Api.Middlewares
{
    /// <summary>
    /// Midewware para Comprobar que la fecha de la sesión está expierada o no. 
    /// En caso positivo devuelve un 301 informando al cliente que la sesión ha expirado.
    /// </summary>
    public class ExpiracionSesionApiMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<UsuarioApiMiddleware> _logger;


        public ExpiracionSesionApiMiddleware(RequestDelegate next, ILogger<UsuarioApiMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context, IOptions<JWT> jwt)
        {
            try
            {
                var token = context.Request.Headers["Authorization"];
                if (!StringValues.IsNullOrEmpty(token))
                {
                    // Se limpia el token...
                    token = token.ToString().Replace("Bearer", string.Empty).Trim();
                    // Obtiene la fecha de expiración la sesión..
                    DateTime fechaValidacion = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(token).ValidTo;
                    if (fechaValidacion <= DateTime.UtcNow)
                    {
                        // Se cumple que la fecha de expiración de sesión es menor a la actual.
                        var response = context.Response;
                        response.ContentType = "application/json";
                        response.StatusCode = 401;
                        var responseModel = new Response<string>() { succeeded = false, message = "Token_expired_time", data = "" };
                        var result = JsonSerializer.Serialize(responseModel);

                        await response.WriteAsync(result);
                    }
                    else
                    {
                        await _next(context);
                    }

                }
                else
                {
                    await _next(context);
                }
            }
            catch (System.Exception error)
            {

                this._logger.LogError(error, "Error ValidacionTJEntregada");
                await this.HandleExceptionMenssageAsync(context, error).ConfigureAwait(false);
                //  throw error;

            }
        }


        private async Task HandleExceptionMenssageAsync(HttpContext context, Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Response<string>() { succeeded = false, message = error?.Message, data = error.StackTrace };
            var result = JsonSerializer.Serialize(responseModel);

            await response.WriteAsync(result);
        }


    }
}

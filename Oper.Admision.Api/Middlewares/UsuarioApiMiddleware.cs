using Oper.Admision.Application.Exceptions;
using Oper.Admision.Application.Wrappers;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace Oper.Admision.Api.Middlewares
{
    public class UsuarioApiMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<UsuarioApiMiddleware> _logger;

        public UsuarioApiMiddleware(RequestDelegate next, ILogger<UsuarioApiMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context, IUsuarioApi usuarioApi)
        {
            try
            {
                var usuarioId = this.GetUsuarioId(context);
                _logger.LogWarning("Claim NameIdentifier: {UsuarioId}", usuarioId);
                await _next(context);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Error en UsuarioApiMiddleware");
                await this.HandleExceptionMenssageAsync(context, error).ConfigureAwait(false);
            }
        }
        private int GetUsuarioId(HttpContext context)
        {
            var claim = context.User.FindFirst(ClaimTypes.NameIdentifier);
            return claim == null ? 0 : int.TryParse(claim.Value, out var id) ? id : 0;
        }

        private async Task HandleExceptionMenssageAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Response<string>
            {
                succeeded = false,
                message = exception?.Message,
                data = exception.StackTrace
            };

            switch (exception)
            {
                case ArgumentInputException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.data = "";
                    break;
                case KeyNotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
    }
}
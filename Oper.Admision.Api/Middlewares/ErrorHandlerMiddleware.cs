using Oper.Admision.Application.Exceptions;
using Oper.Admision.Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace Oper.Admision.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<ErrorHandlerMiddleware>? _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;

        }

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private async Task HandleExceptionMenssageAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Response<string>() { succeeded = false, message = exception?.Message, data = exception.StackTrace };
            switch (exception)
            {
                case ArgumentException:
                case ArgumentInputException:
                case UserNullException:
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




        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                this._logger.LogError(error, "Error aplicación");
                await this.HandleExceptionMenssageAsync(context, error).ConfigureAwait(false);
                // TODO: Loguear errores


            }
        }


    }
}

﻿using Oper.Admision.Application.Exceptions;
using Oper.Admision.Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace Oper.Admision.Api.Middlewares
{
    public class UsuarioApiMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<UsuarioApiMiddleware> _logger;


        public UsuarioApiMiddleware(RequestDelegate next, ILogger<UsuarioApiMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context, IUsuarioApi usuarioApi)
        {
            try
            {
                ((IUsuarioApi)usuarioApi).Insertar(this.GetUsuarioId(context));

                await _next(context);
            }
            catch (System.Exception error)
            {

                this._logger.LogError(error, "Error ValidacionTJEntregada");
                await this.HandleExceptionMenssageAsync(context, error).ConfigureAwait(false);
            }
        }

        private int GetUsuarioId(HttpContext context)
        {
            var claim = context.User.FindFirst("UsuarioId");
            return claim == null ? 0 : int.Parse(claim.Value);
        }

        private async Task HandleExceptionMenssageAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Response<string>() { succeeded = false, message = exception?.Message, data = exception.StackTrace };
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

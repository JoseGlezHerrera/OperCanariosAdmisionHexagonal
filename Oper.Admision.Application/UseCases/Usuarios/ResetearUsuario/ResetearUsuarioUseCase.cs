using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.Correo;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Seguridad;

namespace Oper.Admision.Application.UseCases.Usuarios.Resetear
{
    public class ResetearUsuarioUseCase
    {
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IGestionCorreo _getionCorreo;
        private readonly ILogger<ResetearUsuarioUseCase> _logger;
        public ResetearUsuarioUseCase(IGestionUOW uow, IUsuarioRepository usuarioRepository, IGestionCorreo getionCorreo, ILogger<ResetearUsuarioUseCase> logger)
        {
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._getionCorreo = getionCorreo;
            this._logger = logger;
        }
        private void Validate(ResetearUsuarioInput input)
        {
            this._logger.LogInformation("ResetearUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (input.UsuarioId == 0) throw new ArgumentInputException(Mensaje.Requerido("UsuarioId"));
        }
        public Boolean Execute(ResetearUsuarioInput input)
        {
            Validate(input);
            var usuario = this._usuarioRepository.Get(input.UsuarioId);
            var nuevaClave = GeneradorClaves.Token(6);
            usuario.Password = Encriptacion.Encriptar(nuevaClave);
            usuario.FechaActualizacion = DateTime.Now;
            this._uow.Save();
            this.EnviarNotificacion(usuario, nuevaClave);
            return true;
        }

        private void EnviarNotificacion(Domain.Models.Usuario usuario, string nuevaClave)
        {
            Task.Run(() =>
            {
                this._getionCorreo.Enviar("Belingo Gestión Director: Restablecimiento Password al usuario ", usuario.Notificacion(nuevaClave), usuario.Email);
            });
        }
    }
}

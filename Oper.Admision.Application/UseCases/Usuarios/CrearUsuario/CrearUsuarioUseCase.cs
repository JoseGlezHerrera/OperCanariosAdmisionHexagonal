using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.Correo;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Seguridad;

namespace Oper.Admision.Application.UseCases.Usuarios.Crear
{
    public class CrearUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IGestionCorreo _getionCorreo;
        private readonly ILogger<CrearUsuarioUseCase> _logger;

        public CrearUsuarioUseCase(IMapper mapper, IGestionUOW uow, IUsuarioRepository usuarioRepository, IGestionCorreo getionCorreo, ILogger<CrearUsuarioUseCase> logger)
        {
            this._mapper = mapper;
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._getionCorreo = getionCorreo;
            this._logger = logger;
        }
        private void Validate(CrearUsuarioInput input)
        {
            this._logger.LogInformation("CrearUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);

            if (string.IsNullOrEmpty(input.Dni)) throw new ArgumentInputException(Mensaje.Requerido("Dni"));
            if (string.IsNullOrEmpty(input.Nombre)) throw new ArgumentInputException(Mensaje.Requerido("Nombre"));
            if (string.IsNullOrEmpty(input.Email)) throw new ArgumentInputException(Mensaje.Requerido("Email"));
            if (input.RolId == 0) throw new ArgumentInputException(Mensaje.Requerido("Rol"));
            if (this._usuarioRepository.ExisteDni(input.Dni)) throw new ArgumentInputException(Mensaje.DNI_DUPLICADO(input.Dni));

        }

        public CrearUsuarioOutput Execute(CrearUsuarioInput input)
        {
            Validate(input);
            var usuario = this._mapper.Map<CrearUsuarioInput, Domain.Models.Usuario>(input);
            // Se añade la contraseña y los datos por defectos.
            usuario.FechaCreacion= DateTime.Now;
            _logger.LogWarning("Password recibida (POST): {P}", input.Password);
            var hash = Encriptacion.Encriptar(input.Password);
            _logger.LogWarning("Hash generado: {H}", hash);
            usuario.Password = hash;
            _logger.LogWarning("Contraseña asignada a entidad usuario: {P}", usuario.Password);

            this._usuarioRepository.Create(usuario);
            this._uow.Save();
            this.EnviarNotificacion(usuario, input.Password);
            return this.BuildOutPut(usuario, input.Password);
        }

        private CrearUsuarioOutput BuildOutPut(Domain.Models.Usuario entidad, string nuevaClave)
        {
            var resultado = this._mapper.Map<Domain.Models.Usuario, CrearUsuarioOutput>(entidad);
            return resultado;
        }
        private void EnviarNotificacion(Domain.Models.Usuario usuario, string nuevaClave)
        {
            Task.Run(() =>
            {
                this._getionCorreo.Enviar("Belingo Gestión Director: Crear nuevo usuario", usuario.Notificacion(nuevaClave), usuario.Email);
            });
        }
    }
}

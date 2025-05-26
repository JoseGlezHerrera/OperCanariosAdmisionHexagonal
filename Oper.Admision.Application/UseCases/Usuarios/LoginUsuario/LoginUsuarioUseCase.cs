using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Seguridad;
using System.Runtime.InteropServices;

namespace Oper.Admision.Application.UseCases.Usuarios.Login
{
    public class LoginUsuarioUseCase
    {
        private readonly IMapper _mapper; //para transformar datos entre diferentes tipos
        private readonly IGestionUOW _uow; //maneja transacciones a la bd
        private readonly IUsuarioRepository _usuarioRepository; //permite manipular los datos para la bd
        private readonly ILogger<LoginUsuarioUseCase> _logger; //para depurar el codigo y register mensajes en el sistema

        public LoginUsuarioUseCase(IMapper mapper, IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<LoginUsuarioUseCase> logger)
        {
            this._mapper = mapper;
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._logger = logger;
        }
        private void Validate(LoginUsuarioInput input)
        {
            this._logger.LogInformation("LoginUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);

            if (string.IsNullOrEmpty(input.Nombre)) throw new ArgumentInputException(Mensaje.Requerido("Nombre"));
            if (string.IsNullOrEmpty(input.Password)) throw new ArgumentInputException(Mensaje.Requerido("Passwod"));
        }

        public LoginUsuarioOutput Execute(LoginUsuarioInput input)
        {
            Validate(input);


            var usuario = this._usuarioRepository.Login(input.Nombre, input.Password);
            if (usuario == null)
                _logger.LogWarning("Intento fallido de login con el nombre: {Nombre}", input.Nombre);

            return new LoginUsuarioOutput
            {
                Succeeded = false,
                Mensaje = $"El usuario con nombre '{input.Nombre}' no fue encontrado o la contraseña es incorrecta",
                Errores = new List<string> { "Credenciales inválidas" }
            };
            return BuildOutPut(usuario);
        }
        private LoginUsuarioOutput BuildOutPut(Domain.Models.Usuario entidad)
        {
            var resultado = _mapper.Map<Domain.Models.Usuario, LoginUsuarioOutput>(entidad);
            resultado.Succeeded = true;
            resultado.Mensaje = "Login correcto";
            return resultado;
        }
    }
}

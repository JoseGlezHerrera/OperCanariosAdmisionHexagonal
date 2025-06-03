using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Application.UseCases.Usuarios.Login;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Seguridad;
using Oper.Admision.Infrastructure.Seguridad;

namespace Oper.Admision.Application.UseCases.Usuarios.Login
{
    public class LoginUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<LoginUsuarioUseCase> _logger;
        private readonly JwtGenerator _jwtGenerator;

        public LoginUsuarioUseCase(
            IMapper mapper,
            IGestionUOW uow,
            IUsuarioRepository usuarioRepository,
            ILogger<LoginUsuarioUseCase> logger,
            JwtGenerator jwtGenerator)
        {
            _mapper = mapper;
            _uow = uow;
            _usuarioRepository = usuarioRepository;
            _logger = logger;
            _jwtGenerator = jwtGenerator;
        }

        private void Validate(LoginUsuarioInput input)
        {
            _logger.LogInformation("LoginUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (string.IsNullOrEmpty(input.Nombre)) throw new ArgumentInputException(Mensaje.Requerido("Nombre"));
            if (string.IsNullOrEmpty(input.Password)) throw new ArgumentInputException(Mensaje.Requerido("Password"));
        }

        public LoginUsuarioOutput Execute(LoginUsuarioInput input)
        {
            Validate(input);

            var usuario = _usuarioRepository.Login(input.Nombre, input.Password);
            if (usuario == null)
            {
                _logger.LogWarning("Intento fallido de login con el nombre: {Nombre}", input.Nombre);
                return new LoginUsuarioOutput
                {
                    Succeeded = false,
                    Mensaje = $"El usuario con nombre '{input.Nombre}' no fue encontrado o la contraseña es incorrecta",
                    Errores = new List<string> { "Credenciales inválidas" }
                };
            }

            return BuildOutput(usuario);
        }

        private LoginUsuarioOutput BuildOutput(Domain.Models.Usuario usuario)
        {
            _logger.LogInformation("🟨 Usuario recibido del repositorio: {@usuario}", usuario);
            var resultado = _mapper.Map<Domain.Models.Usuario, LoginUsuarioOutput>(usuario);

            //Aquí se genera el token JWT con nameid
            resultado.Token = _jwtGenerator.GenerarToken(usuario);
            resultado.Succeeded = true;
            resultado.Mensaje = "Login correcto";
            _logger.LogInformation("🟩 Resultado del mapping: {@resultado}", resultado);
            return resultado;
        }
    }
}
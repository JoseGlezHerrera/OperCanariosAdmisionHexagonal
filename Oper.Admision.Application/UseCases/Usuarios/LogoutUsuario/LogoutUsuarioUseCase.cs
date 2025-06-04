using Oper.Admision.Domain.IRepositories;

namespace Oper.Admision.Application.UseCases.Usuarios.LogoutUsuario
{
    public class LogoutUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LogoutUsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<LogoutUsuarioOutput> EjecutarAsync(LogoutUsuarioInput input)
        {
            var usuario = await _usuarioRepository.ObtenerPorNombreAsync(input.NombreUsuario);

            if (usuario == null)
            {
                return new LogoutUsuarioOutput
                {
                    Exito = false,
                    Mensaje = "El usuario no existe."
                };
            }
            return new LogoutUsuarioOutput
            {
                Exito = true,
                Mensaje = $"Usuario '{input.NombreUsuario}' cerró sesión correctamente."
            };
        }
    }
}


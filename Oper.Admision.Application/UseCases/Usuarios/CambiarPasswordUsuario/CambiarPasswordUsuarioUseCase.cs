using AutoMapper;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Seguridad;
using Microsoft.Extensions.Logging;

namespace Oper.Admision.Application.UseCases.Usuarios.CambiarPassword
{
    public class CambiarPasswordUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<CambiarPasswordUsuarioUseCase> _logger;
        public CambiarPasswordUsuarioUseCase(IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<CambiarPasswordUsuarioUseCase> logger)
        {
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._logger = logger;
        }
        private void Validate(CambiarPasswordUsuarioInput input)
        {
            this._logger.LogInformation("CambiarPasswordUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (input.UsuarioId == 0) throw new ArgumentInputException(Mensaje.Requerido("UsuarioId"));
        }
        public Boolean Execute(CambiarPasswordUsuarioInput input)
        {
            Validate(input);
            var usuario = this._usuarioRepository.Get(input.UsuarioId);
            usuario.Password = Encriptacion.Encriptar(input.Password);
            usuario.FechaActualizacion = DateTime.Now;
            this._uow.Save();
            return true;
        }


    }
}

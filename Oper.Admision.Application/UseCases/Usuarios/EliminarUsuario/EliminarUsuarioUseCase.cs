using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;

namespace Oper.Admision.Application.UseCases.Usuarios.Eliminar
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
            this._logger.LogInformation("EliminarUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (input.UsuarioId == 0) throw new ArgumentInputException(Mensaje.Requerido("UsuarioId"));
        }
        public void Execute(CambiarPasswordUsuarioInput input)
        {
            Validate(input);
            this._usuarioRepository.Delete(input.UsuarioId);
            this._uow.Save();
        }


    }
}

using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;

namespace Oper.Admision.Application.UseCases.Usuarios.DarBajaAlta
{
    public class DarBajaAltaUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<DarBajaAltaUsuarioUseCase> _logger;
        public DarBajaAltaUsuarioUseCase(IMapper mapper, IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<DarBajaAltaUsuarioUseCase> logger)
        {
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._logger = logger;
            this._mapper = mapper;
        }
        private void Validate(DarBajaAltaUsuarioInput input)
        {
            this._logger.LogInformation("DarBajaAltaUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (input.UsuarioId == 0) throw new ArgumentInputException(Mensaje.Requerido("UsuarioId"));
        }
        public DarBajaAltaUsuarioOutput Execute(DarBajaAltaUsuarioInput input)
        {
            Validate(input);
            var entidad = this._usuarioRepository.Get(input.UsuarioId);
            var fecha = DateTime.Now;
            if (entidad.FechaBaja.HasValue)
                entidad.FechaBaja = null;
            else
                entidad.FechaBaja = fecha;
            entidad.FechaActualizacion = fecha;
            this._usuarioRepository.Update(entidad);
            this._uow.Save();
            return this.BuildOutPut(entidad);
        }

        private DarBajaAltaUsuarioOutput BuildOutPut(Domain.Models.Usuario usuario)
        {
            var resultado = this._mapper.Map<Domain.Models.Usuario, DarBajaAltaUsuarioOutput>(usuario);
            return resultado;
        }
    }
}

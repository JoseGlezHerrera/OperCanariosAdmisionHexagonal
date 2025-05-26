using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;

namespace Oper.Admision.Application.UseCases.Usuarios.Editar
{
    public class EditarUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<EditarUsuarioUseCase> _logger;
        public EditarUsuarioUseCase(IMapper mapper, IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<EditarUsuarioUseCase> logger)
        {
            this._mapper = mapper;
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._logger = logger;
        }
        private void Validate(EditarUsuarioInput input)
        {
            this._logger.LogInformation("EditarUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (input.UsuarioId == 0) throw new ArgumentInputException(Mensaje.Requerido("UsuarioId"));
            if (string.IsNullOrEmpty(input.Dni)) throw new ArgumentInputException(Mensaje.Requerido("Dni"));
            if (this._usuarioRepository.ExisteNombre(input.UsuarioId, input.Dni)) throw new ArgumentInputException(Mensaje.DNI_DUPLICADO(input.Dni));
            if (string.IsNullOrEmpty(input.Nombre)) throw new ArgumentInputException(Mensaje.Requerido("Nombre"));
            if (string.IsNullOrEmpty(input.Email)) throw new ArgumentInputException(Mensaje.Requerido("Email"));
            if (input.RolId == 0) throw new ArgumentInputException(Mensaje.Requerido("Rol"));
        }
        public EditarUsuarioOutput Execute(EditarUsuarioInput input)
        {
            Validate(input);
            var usuario = this._usuarioRepository.Get(input.UsuarioId);
            usuario.Dni = input.Dni;
            usuario.Nombre = input.Nombre;
            usuario.Email = input.Email;
            usuario.RolId = input.RolId;
            usuario.FechaActualizacion = DateTime.Now;
            usuario.FechaBaja = input.FechaBaja;

            this._usuarioRepository.Update(usuario);
            this._uow.Save();
            return this.BuildOutPut(usuario);
        }

        private EditarUsuarioOutput BuildOutPut(Domain.Models.Usuario usuario)
        {
            var resultado = this._mapper.Map<Domain.Models.Usuario, EditarUsuarioOutput>(usuario);
            return resultado;
        }
    }
}

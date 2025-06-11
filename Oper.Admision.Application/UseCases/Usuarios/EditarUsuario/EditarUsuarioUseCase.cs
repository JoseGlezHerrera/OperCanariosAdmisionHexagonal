using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Infrastructure.Repositories;

namespace Oper.Admision.Application.UseCases.Usuarios.Editar
{
    public class EditarUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<EditarUsuarioUseCase> _logger;
        private readonly IRolRepository _rolRepository;
        public EditarUsuarioUseCase(IMapper mapper, IGestionUOW uow, IUsuarioRepository usuarioRepository, IRolRepository rolRepository, ILogger<EditarUsuarioUseCase> logger)
        {
            this._mapper = mapper;
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._rolRepository = rolRepository;
            this._logger = logger;
        }
        private void Validate(EditarUsuarioInput input)
        {
            this._logger.LogInformation("EditarUsuarioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (input.UsuarioId == 0) throw new ArgumentInputException(Mensaje.Requerido("UsuarioId"));
            if (string.IsNullOrEmpty(input.Dni)) throw new ArgumentInputException(Mensaje.Requerido("Dni"));
            if (this._usuarioRepository.ExisteDniParaOtroUsuario(input.UsuarioId, input.Dni)) throw new ArgumentInputException(Mensaje.DNI_DUPLICADO(input.Dni));
            if (string.IsNullOrEmpty(input.Nombre)) throw new ArgumentInputException(Mensaje.Requerido("Nombre"));
            if (string.IsNullOrEmpty(input.Email)) throw new ArgumentInputException(Mensaje.Requerido("Email"));
            if (input.RolId == 0) throw new ArgumentInputException(Mensaje.Requerido("Rol"));
        }
        public EditarUsuarioOutput Execute(EditarUsuarioInput input)
        {
            var usuario = _usuarioRepository.Get(input.UsuarioId);
            if (usuario == null)
                throw new KeyNotFoundException($"No existe el usuario con id {input.UsuarioId}");
            if (!string.IsNullOrEmpty(input.Dni) && input.Dni != usuario.Dni && _usuarioRepository.ExisteDniParaOtroUsuario(input.UsuarioId, input.Dni))
                throw new ArgumentException("Ya existe otro usuario con ese DNI.");
            if (!string.IsNullOrEmpty(input.Email) && input.Email != usuario.Email)
            {
                var todos = _usuarioRepository.GetAll();
                if (todos.Any(u => u.Email != null && u.UsuarioId != input.UsuarioId && u.Email.ToLower() == input.Email.ToLower()))
                    throw new ArgumentException("Ya existe otro usuario con ese Email.");
            }

            if (string.IsNullOrEmpty(input.Nombre))
                throw new ArgumentNullException(nameof(input.Nombre));
            if (string.IsNullOrEmpty(input.Dni))
                throw new ArgumentNullException(nameof(input.Dni));
            if (string.IsNullOrEmpty(input.Email))
                throw new ArgumentNullException(nameof(input.Email));
            if (input.RolId <= 0)
                throw new ArgumentException("Debe especificarse un Rol válido.");

            var roles = _rolRepository.GetAll();
            if (!roles.Any(r => r.RolId == input.RolId))
                throw new ArgumentException("El rol especificado no existe.");

            usuario.Dni = input.Dni;
            usuario.Nombre = input.Nombre;
            usuario.Email = input.Email;
            usuario.RolId = input.RolId;
            usuario.FechaBaja = input.FechaBaja;
            usuario.FechaActualizacion = DateTime.Now;

            _usuarioRepository.Update(usuario);
            _uow.Save();

            var output = _mapper.Map<EditarUsuarioOutput>(usuario);
            output.Mensaje = $"Usuario {usuario.UsuarioId} editado correctamente.";
            return output;
        }
        private EditarUsuarioOutput BuildOutPut(Domain.Models.Usuario usuario)
        {
            var resultado = this._mapper.Map<Domain.Models.Usuario, EditarUsuarioOutput>(usuario);
            return resultado;
        }
    }
}

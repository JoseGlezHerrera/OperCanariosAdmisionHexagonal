using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain;
using Oper.Admision.Application.UseCases.Usuarios.EliminarUsuario;
using System;

namespace Oper.Admision.Application.UseCases.Usuarios.EliminarUsuario
{
    public class EliminarUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IGestionUOW _uow;

        public EliminarUsuarioUseCase(IUsuarioRepository usuarioRepository, IGestionUOW uow)
        {
            _usuarioRepository = usuarioRepository;
            _uow = uow;
        }

        public string Execute(EliminarUsuarioInput input)
        {
            var usuario = _usuarioRepository.Get(input.UsuarioId);
            if (usuario == null)
                throw new KeyNotFoundException($"No existe el usuario con id {input.UsuarioId}");

            usuario.Eliminado = true;
            usuario.FechaBaja = DateTime.Now;
            _usuarioRepository.Update(usuario);
            _uow.Save();

            return $"Usuario {usuario.UsuarioId} eliminado correctamente.";
        }
    }
}
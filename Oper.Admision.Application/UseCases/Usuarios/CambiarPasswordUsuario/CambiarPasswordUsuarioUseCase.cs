using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Seguridad;
using System;

namespace Oper.Admision.Application.UseCases.Usuarios.CambiarPassword
{
    public class CambiarPasswordUsuarioUseCase
    {
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<CambiarPasswordUsuarioUseCase> _logger;

        public CambiarPasswordUsuarioUseCase(
            IGestionUOW uow,
            IUsuarioRepository usuarioRepository,
            ILogger<CambiarPasswordUsuarioUseCase> logger)
        {
            _uow = uow;
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        private void Validate(CambiarPasswordUsuarioInput input)
        {
            if (input == null)
                throw new ArgumentInputException("Input no puede ser null.");

            if (input.UsuarioId == 0)
                throw new ArgumentInputException("UsuarioId es requerido.");
        }

        public bool Execute(CambiarPasswordUsuarioInput input)
        {
            Validate(input);

            _logger.LogInformation("Buscando usuario con Id {UsuarioId}", input.UsuarioId);
            var usuario = _usuarioRepository.Get(input.UsuarioId);
            _logger.LogInformation("Usuario obtenido: {@Usuario}", usuario);

            if (usuario == null || usuario.UsuarioId == 0)
            {
                _logger.LogWarning("Usuario con Id {UsuarioId} no encontrado", input.UsuarioId);
                throw new KeyNotFoundException($"Usuario con Id {input.UsuarioId} no encontrado.");
            }

            try
            {
                //Iniciar transacción
                _uow.BeginTransaction();
                _logger.LogInformation("Iniciando transacción para cambiar la contraseña.");

                //Generar hash de la nueva contraseña
                var hash = Encriptacion.Encriptar(input.Password);

                _logger.LogWarning("Password recibido en texto plano: {P}", input.Password ?? "null");
                _logger.LogWarning("Hash generado: {H}", hash);
                _logger.LogWarning("Hash actualmente en la BD: {HDB}", usuario.Password);

                //Si es la misma, no hacemos nada
                if (usuario.Password == hash)
                {
                    _logger.LogWarning("La nueva contraseña es igual a la actual. No se realizó ningún cambio.");
                    return false;
                }

                //Asignamos el hash a la entidad y actualizamos fecha
                usuario.Password = hash;
                usuario.FechaActualizacion = DateTime.Now;

                
                _usuarioRepository.Update(usuario);

                // GUARDA los cambios en la base
                _uow.Save();
                _logger.LogInformation("Cambios guardados en la base de datos, procediendo a confirmar transacción");

                // Confirmamos la transacción
                _uow.Commit();
                _logger.LogInformation("Transacción confirmada, cambios persistidos en la base de datos.");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cambiando password para UsuarioId {UsuarioId}", input.UsuarioId);
                _uow.RollBack();
                _logger.LogInformation("Se ha realizado un Rollback debido a un error.");
                throw;
            }
        }
    }
}
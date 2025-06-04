using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using Oper.Admision.Domain.Seguridad;

namespace Oper.Admision.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GestionContext _context;
        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(GestionContext context, ILogger<UsuarioRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public Usuario? Get(int usuarioId)
        {
            return this._context.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
        }

        public ICollection<Usuario> GetAll()
        {
            return this._context.Usuarios
                .Where(u => !u.Eliminado)
                .Select(u => new Usuario
                {
                    UsuarioId = u.UsuarioId,
                    Nombre = u.Nombre,
                    Email = u.Email ?? string.Empty,
                    Dni = u.Dni ?? string.Empty,
                    FechaCreacion = u.FechaCreacion,
                    FechaActualizacion = u.FechaActualizacion,
                    FechaBaja = u.FechaBaja,
                    Bloqueado = u.Bloqueado,
                    Eliminado = u.Eliminado,
                    RolId = u.RolId ?? 0
                })
                .ToList();
        }

        public void Create(Usuario usuario)
        {
            
            this._context.Usuarios.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            this._context.Entry(usuario).State = EntityState.Modified;
        }

        public void Delete(int usuarioId)
        {
            var entidad = this.Get(usuarioId);
            entidad.Eliminado = true;
            this._context.Entry(entidad).State = EntityState.Modified;
        }

        public bool ExisteNombre(int? usuarioId, string nombre)
        {
            if (!usuarioId.HasValue)
                return this._context.Usuarios.Any(u => u.Nombre == nombre && !u.Eliminado);
            else
                return this._context.Usuarios.Any(u => u.Nombre == nombre && !u.Eliminado && u.UsuarioId == usuarioId);
        }

        public Usuario? Login(string nombre, string passwordEncriptada)
        {
            var usuario = _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefault(u =>
                    u.Nombre == nombre &&
                    u.Password == passwordEncriptada &&
                    !u.Eliminado);

            if (usuario == null)
                return null;

            // LOG de seguridad
            _logger.LogWarning("Login confirmado. UsuarioID: {UsuarioId}, Nombre: {Nombre}", usuario.UsuarioId, usuario.Nombre);

            return usuario;
        }

        public Usuario? Get(string email)
        {
            if (this.ExisteEmail(email))
            {
                return this._context.Usuarios.FirstOrDefault(u => u.Email == email);
            }
            else
            {
                return null;
            }
        }

        public bool ExisteEmail(string email)
        {
            return this._context.Usuarios.Any(u => u.Email == email);
        }

        public bool ExisteNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> ObtenerPorNombreAsync(string nombreUsuario)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Nombre == nombreUsuario);
        }
    }
}
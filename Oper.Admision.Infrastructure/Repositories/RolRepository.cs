using Microsoft.EntityFrameworkCore;
using Oper.Admision.Domain.Models;
using Oper.Admision.Domain.IRepositories;

namespace Oper.Admision.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly GestionContext _context;

        public RolRepository(GestionContext context)
        {
            this._context = context;
        }

        public ICollection<Rol> GetAll()
        {
            var rolesConUsuarios = this._context.Roles
                .Include(r => r.Usuarios)
                .ToList();

            foreach (var rol in rolesConUsuarios)
            {
                Console.WriteLine($"Rol: {rol.Nombre}, Usuarios: {rol.Usuarios.Count}");
                foreach (var usuario in rol.Usuarios)
                {
                    Console.WriteLine($"Usuario: {usuario.Nombre}");
                }
            }

            return rolesConUsuarios;
        }



        public int GetId(int usuarioId)
        {
            return (int)this._context.Usuarios
                .Where(u => u.UsuarioId == usuarioId)
                .Select(u => u.RolId)
                .FirstOrDefault();
        }
    }
}


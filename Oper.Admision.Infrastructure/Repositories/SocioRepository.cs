using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Infrastructure.Repositories
{
    public class SocioRepository : ISocioRepository
    {
        private readonly GestionContext _context;
        private readonly ILogger<SocioRepository> _logger;
        public SocioRepository(GestionContext context, ILogger<SocioRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public Socio? Get(int id_socio)
        {
            return this._context.Socios
                .Where(u => u.id_socio == id_socio)
                .Select(u => new Socio
                {
                    id_socio = u.id_socio,
                    dni = u.dni ?? string.Empty,
                    nombre = u.nombre ?? string.Empty,
                    apel1 = u.apel1 ?? string.Empty,
                    apel2 = u.apel2 ?? string.Empty,
                    calle = u.calle ?? string.Empty,
                    telefono = u.telefono ?? string.Empty,
                    comentario = u.comentario ?? string.Empty,
                    fecha_modificacion = u.fecha_modificacion ?? DateTime.MinValue,
                    fecha_baja = u.fecha_baja
                })
                .FirstOrDefault();
        }
        public void Create(Socio socio)
        {
            this._context.Socios.Add(socio);
        }

        public void Delete(int id_socio)
        {
            var entidad = this.Get(id_socio);
            //entidad.Eliminado = true;
            this._context.Entry(entidad).State = EntityState.Modified;
        }



        public bool ExisteNombre(int? id_socio, string nombre)
        {
            if (!id_socio.HasValue)
                return this._context.Usuarios.Any(u => u.Nombre == nombre && !u.Eliminado);
            else
                return this._context.Usuarios.Any(u => u.Nombre == nombre && !u.Eliminado && u.UsuarioId == id_socio);
        }



        public ICollection<Socio> GetAll()
        {
            return this._context.Socios
                               .Select(u => new Socio
                               {
                                   id_socio = u.id_socio,
                                   nombre = u.nombre ?? string.Empty,
                                   apel1 = u.apel1 ?? string.Empty,
                                   apel2 = u.apel2 ?? string.Empty,
                                   dni = u.dni ?? string.Empty,
                                   calle = u.calle ?? string.Empty,
                                   telefono = u.telefono ?? string.Empty,
                                   comentario = u.comentario ?? string.Empty,
                                   fecha_modificacion = u.fecha_modificacion ?? DateTime.MinValue,
                                   fecha_baja = u.fecha_baja
                               })
                               .ToList();
        }
        public void Update(Socio socio)
        {
            this._context.Entry(socio).State = EntityState.Modified;
        }

        Socio ISocioRepository.Get(int id_socio)
        {
            return this.Get(id_socio) ?? throw new KeyNotFoundException($"No se encontró un socio con el id {id_socio}.");
        }

        public bool ExisteNombre(string nombre)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Socio>> ObtenerCumpleañerosDeHoyAsync()
        {
            var hoy = DateTime.Today;
            return await _context.Socios
                .Where(s => s.fecha_nacimiento.Day == hoy.Day && s.fecha_nacimiento.Month == hoy.Month)
                .ToListAsync();
        }
        public async Task<List<Socio>> ObtenerTodosAsync()
        {
            return await _context.Socios.ToListAsync();
        }
        public async Task<Socio> GetByDniAsync(string dni)
        {
            return await _context.Socios
                .FirstOrDefaultAsync(s => s.dni == dni);
        }
    }
}


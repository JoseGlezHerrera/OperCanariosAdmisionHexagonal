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
    public class SesionRepository : ISesionRepository
    {

        private readonly GestionContext _context;
        private readonly ILogger<SesionRepository> _logger;
        public SesionRepository(GestionContext context, ILogger<SesionRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public void Create(Sesion sesion)
        {
            this._context.Sesion.Add(sesion);
        }

        public void Delete(int id_sesion)
        {
            var entidad = this.Get(id_sesion);
            //entidad.Eliminado = true;
            this._context.Entry(entidad).State = EntityState.Modified;
        }

        public Sesion Get(int id_sesion)
        {
            return this._context.Sesion
                .Where(u => u.id_sesion == id_sesion)
                .Select(u => new Sesion
                {
                    id_sesion = u.id_sesion,
                    fecha_inicio = u.fecha_inicio,
                    hombres = u.hombres,
                    mujeres = u.mujeres,
                    nuevos = u.nuevos,
                    habituales = u.habituales,
                    fecha_fin = u.fecha_fin,
                    id_sede = u.id_sede,
                    //sede = new Sede

                })
                .FirstOrDefault();
        }

        public ICollection<Sesion> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Sesion sesion)
        {
            this._context.Entry(sesion).State = EntityState.Modified;
        }
    }
}

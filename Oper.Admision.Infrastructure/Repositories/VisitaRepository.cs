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
    public class VisitaRepository : IVisitaRepository
    {
        private readonly GestionContext _context;
        private readonly ILogger<VisitaRepository> _logger;

        public VisitaRepository(GestionContext context, ILogger<VisitaRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public void Create(Visita visita)
        {
            this._context.Visita.Add(visita);
        }

        public void Delete(int id_visita)
        {
            var entidad = this.Get(id_visita);
            //entidad.Eliminado = true;
            this._context.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }

        public Visita Get(int id_visita)
        {
            return this._context.Visita
                .Where(u => u.id_visita == id_visita)
                .Select(u => new Visita
                {
                    id_visita = u.id_visita,
                    id_socio = u.id_socio,
                    id_sesion = u.id_sesion,
                    id_sede = u.id_sede,
                    fecha_hora = u.fecha_hora
                })
                .FirstOrDefault();
        }

        public ICollection<Visita> GetAll()
        {
            return this._context.Visita
                .Select(u => new Visita
                {
                    id_visita = u.id_visita,
                    id_socio = u.id_socio,
                    id_sesion = u.id_sesion,
                    id_sede = u.id_sede,
                    fecha_hora = u.fecha_hora
                })
                .ToList();
        }

        public void Update(Visita visita)
        {
            this._context.Entry(visita).State = EntityState.Modified;
        }

        Socio IVisitaRepository.Get(int id_visita)
        {
            throw new NotImplementedException();
        }
    }

}

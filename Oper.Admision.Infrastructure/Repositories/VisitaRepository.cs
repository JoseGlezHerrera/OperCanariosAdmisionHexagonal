using Microsoft.EntityFrameworkCore;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using Oper.Admision.Infrastructure;

namespace Oper.Admision.Infrastructure.Repositories
{
    public class VisitaRepository : IVisitaRepository
    {
        private readonly GestionContext _context;

        public VisitaRepository(GestionContext context)
        {
            _context = context;
        }

        public async Task<Visita?> ObtenerPorIdAsync(int id)
        {
            return await _context.Visita.FindAsync(id);
        }

        public async Task<List<Visita>> ObtenerPorSocioIdAsync(int socioId)
        {
            return await _context.Visita
                .Where(v => v.id_socio == socioId)
                .ToListAsync();
        }

        public async Task AgregarAsync(Visita visita)
        {
            try
            {
                _context.Visita.Add(visita);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ Error al guardar Visita: " + ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task EliminarAsync(int id)
        {
            var visita = await _context.Visita.FindAsync(id);
            if (visita != null)
            {
                _context.Visita.Remove(visita);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Visita>> ObtenerTodasAsync()
        {
            return await _context.Visita.ToListAsync();
        }
        public async Task ActualizarAsync (Visita visita)
        {
            var entidadExistente = await _context.Visita.FindAsync(visita.id_visita);
            if (entidadExistente == null)
                throw new Exception("Visita a actualizar no encontrada");
            entidadExistente.fecha_hora = visita.fecha_hora;
            entidadExistente.id_sesion = visita.id_sesion;
            entidadExistente.motivo = visita.motivo;
            _context.Visita.Update(entidadExistente);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Visita>> ObtenerPorFechaAsync(DateTime fecha)
        {
            var fechaInicio = fecha.Date;
            var fechaFin = fecha.Date.AddDays(1);

            return await _context.Visita
                .Where(v => v.fecha_hora >= fechaInicio && v.fecha_hora < fechaFin)
                .ToListAsync();
        }
        public async Task InsertAsync(Visita visita)
        {
            await _context.Visita.AddAsync(visita);
        }
    }
}
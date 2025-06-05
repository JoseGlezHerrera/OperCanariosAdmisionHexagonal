using Microsoft.EntityFrameworkCore;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Infrastructure.Repositories
{
    public class ProblematicoRepository : IProblematicoRepository
    {
        private readonly GestionContext _context;

        public ProblematicoRepository(GestionContext context)
        {
            _context = context;
        }

        public async Task<List<ProblematicoVista>> ObtenerProblematicosAsync(int? idSesion)
        {
            StringBuilder consulta = new StringBuilder();
            consulta.Append("SELECT problematicos.regla AS Regla, problematicos.comentario AS Comentario, ");
            consulta.Append("CASE WHEN problematicos.gobcan = 1 THEN 1 ");
            consulta.Append("WHEN problematicos.prohibida_entrada = 1 THEN 2 ");
            consulta.Append("WHEN problematicos.conflictivo = 1 THEN 3 ");
            consulta.Append("ELSE 0 END AS TipoProblematico, ");
            consulta.Append("socios.dni AS Dni, problematicos.fecha_crea AS FechaCreacion ");
            consulta.Append("FROM problematicos ");
            consulta.Append("LEFT JOIN socios ON socios.id_socio = problematicos.id_socio ");

            if (idSesion.HasValue && idSesion.Value > 0)
            {
                consulta.AppendFormat("WHERE problematicos.id_sesion = {0} ", idSesion.Value);
            }

            consulta.Append("ORDER BY problematicos.fecha_crea DESC");

            try
            {
                return await _context.ProblematicoVista
                    .FromSqlRaw(consulta.ToString())
                    .ToListAsync();
            }
            catch
            {
                throw;
            }

        }
        public async Task<Problematico> InsertarProblematicoAsync(Problematico tipoProblematico, string dni)
        {
            var socio = await _context.Socios.FirstOrDefaultAsync(s => s.dni == dni);
            if (socio == null)
                throw new Exception($"No se encontró un socio con DNI: {dni}");

            return await InsertarProblematicoAsync(tipoProblematico, socio);
        }
        public async Task<Problematico> InsertarProblematicoAsync(Problematico tipoProblematico, Socio socio, ReglaConflictivo reglaConflictivo)
        {
            tipoProblematico.regla = reglaConflictivo.nombre;
            tipoProblematico.comentario = reglaConflictivo.comentario;
            return await InsertarProblematicoAsync(tipoProblematico, socio);
        }
        public async Task<Problematico> InsertarProblematicoAsync(Problematico tipoProblematico, Socio socio)
        {
            try
            {
                tipoProblematico.id_socio = socio.id_socio;
                tipoProblematico.fecha_crea = DateTime.Now;
                tipoProblematico.visible = true;

                await _context.AddAsync(tipoProblematico);
                await _context.SaveChangesAsync();

                return tipoProblematico;
            }
            catch (DbUpdateException dbEx)
            {
                var inner = dbEx.InnerException?.Message ?? dbEx.Message;
                throw new Exception($"Error al guardar el Problematico en base de datos: {inner}", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al insertar Problematico: " + ex.Message, ex);
            }
        }
        public async Task<Problematico?> GetByIdAsync(int id)
        {
            return await _context.Problematicos
                .FirstOrDefaultAsync(p => p.id_problematicos == id);
        }
        public async Task UpdateAsync(Problematico problematico)
        {
            _context.Problematicos.Update(problematico);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarAsync(Problematico problematico)
        {
            _context.Problematicos.Remove(problematico);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ProblematicoVista>> FiltrarPorTipoAsync(string tipo)
        {
            var tipoNormalizado = tipo.ToLower();
            StringBuilder consulta = new StringBuilder();
            consulta.Append("Select problematicos.regla AS Regla, problematicos.comentario AS Comentario, ");
            consulta.Append("CASE WHEN problematicos.gobcan = 1 THEN 1 ");
            consulta.Append("WHEN problematicos.prohibida_entrada = 1 THEN 2 ");
            consulta.Append("WHEN problematicos.conflictivo = 1 THEN 3 ");
            consulta.Append("ELSE 0 END AS TipoProblematico, ");
            consulta.Append("socios.dni AS Dni, problematicos.fecha_crea AS FechaCreacion ");
            consulta.Append("FROM problematicos ");
            consulta.Append("LEFT JOIN socios ON socios.id_socio = problematicos.id_socio ");
            consulta.Append("WHERE ");

            switch(tipoNormalizado)
            {
                case "conflictivo":
                    consulta.Append("problematicos.conflictivo = 1 ");
                    break;
                case "prohibidaentrada":
                    consulta.Append("problematicos.prohibida_entrada = 1 ");
                    break;
                case "gobcan":
                    consulta.Append("problematicos.gobcan = 1 ");
                    break;
                default:
                    return new List<ProblematicoVista>(); // La consulta no es válida, retornar lista vacía
            }
            consulta.Append("ORDER BY problematicos.fecha_crea DESC");
            return await _context.ProblematicoVista.FromSqlRaw(consulta.ToString()).ToListAsync();

        }
    }
}
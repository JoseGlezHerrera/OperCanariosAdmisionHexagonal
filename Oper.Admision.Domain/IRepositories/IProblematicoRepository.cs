using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Oper.Admision.Domain.IRepositories
{
    public interface IProblematicoRepository
    {
        Task<List<ProblematicoVista>> ObtenerProblematicosAsync(int? idSesion);
        Task<Problematico> InsertarProblematicoAsync(Problematico tipoProblematico, string dni);
        Task<Problematico> InsertarProblematicoAsync(Problematico tipoProblematico, Socio socio, ReglaConflictivo reglaConflictivo);
        Task<Problematico> InsertarProblematicoAsync(Problematico tipoProblematico, Socio socio);
        Task<Problematico?> GetByIdAsync(int id);
        Task UpdateAsync(Problematico problematico);
        Task EliminarAsync(Problematico problematico);
    }
}

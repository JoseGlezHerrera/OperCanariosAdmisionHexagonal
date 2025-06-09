using Oper.Admision.Domain.Models;

namespace Oper.Admision.Domain.IRepositories
{
    public interface IVisitaRepository
    {
        Task<Visita?> ObtenerPorIdAsync(int id);
        Task<List<Visita>> ObtenerPorSocioIdAsync(int socioId);
        Task AgregarAsync(Visita visita);
        Task ActualizarAsync(Visita visita);
        Task<int> EliminarAsync(int id);
        Task<List<Visita>> ObtenerTodasAsync();
        Task<List<Visita>> ObtenerPorFechaAsync(DateTime fecha);
        Task InsertAsync(Visita visita);
        bool ExisteVisita(int socioId, int sesionId);
        void Registrar(Visita visita);
    }
}
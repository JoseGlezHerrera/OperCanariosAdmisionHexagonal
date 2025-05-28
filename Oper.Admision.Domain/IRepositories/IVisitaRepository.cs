using Oper.Admision.Domain.Models;

namespace Oper.Admision.Domain.IRepositories
{
    public interface IVisitaRepository
    {
        Task<Visita?> ObtenerPorIdAsync(int id);
        Task<List<Visita>> ObtenerPorSocioIdAsync(int socioId);
        Task AgregarAsync(Visita visita);
        Task ActualizarAsync(Visita visita);
        Task EliminarAsync(int id);
        Task<List<Visita>> ObtenerTodasAsync();

    }
}
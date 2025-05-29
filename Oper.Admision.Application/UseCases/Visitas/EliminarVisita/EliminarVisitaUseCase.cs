using Oper.Admision.Domain.IRepositories;

namespace Oper.Admision.Application.UseCases.Visita.EliminarVisita
{
    public class EliminarVisitaUseCase
    {
        private readonly IVisitaRepository _visitaRepository;

        public EliminarVisitaUseCase(IVisitaRepository visitaRepository)
        {
            _visitaRepository = visitaRepository;
        }

        public async Task EjecutarAsync(EliminarVisitaInput input)
        {
            await _visitaRepository.EliminarAsync(input.Id);
        }
    }
}
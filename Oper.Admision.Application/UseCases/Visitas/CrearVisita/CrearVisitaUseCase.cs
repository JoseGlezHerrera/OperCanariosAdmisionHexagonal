using AutoMapper;
using Oper.Admision.Domain.IRepositories;
using DominioVisita = Oper.Admision.Domain.Models.Visita;

namespace Oper.Admision.Application.UseCases.Visitas.CrearVisita
{
    public class CrearVisitaUseCase
    {
        private readonly IVisitaRepository _visitaRepository;
        private readonly IMapper _mapper;

        public CrearVisitaUseCase(IVisitaRepository visitaRepository, IMapper mapper)
        {
            _visitaRepository = visitaRepository;
            _mapper = mapper;
        }

        public async Task EjecutarAsync(CrearVisitaInput input)
        {
            var visita = _mapper.Map<DominioVisita>(input);
            await _visitaRepository.AgregarAsync(visita);
        }
    }
}
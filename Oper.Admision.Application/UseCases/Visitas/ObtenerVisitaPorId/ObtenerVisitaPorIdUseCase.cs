using AutoMapper;
using Oper.Admision.Application.UseCases.Visitas.ObtenerVisitaPorId;
using Oper.Admision.Domain.IRepositories;
using DominioVisita = Oper.Admision.Domain.Models.Visita;

namespace Oper.Admision.Application.UseCases.Visita.ObtenerVisitaPorId
{
    public class ObtenerVisitaPorIdUseCase
    {
        private readonly IVisitaRepository _visitaRepository;
        private readonly IMapper _mapper;

        public ObtenerVisitaPorIdUseCase(IVisitaRepository visitaRepository, IMapper mapper)
        {
            _visitaRepository = visitaRepository;
            _mapper = mapper;
        }

        public async Task<ObtenerVisitaPorIdResponse?> EjecutarAsync(ObtenerVisitaPorIdInput input)
        {
            DominioVisita? visita = await _visitaRepository.ObtenerPorIdAsync(input.Id);

            if (visita is null)
                return null;

            return _mapper.Map<ObtenerVisitaPorIdResponse>(visita);
        }
    }
}
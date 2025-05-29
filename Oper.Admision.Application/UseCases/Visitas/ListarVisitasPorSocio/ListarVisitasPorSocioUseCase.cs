using AutoMapper;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using Oper.Admision.Application.UseCases.Visitas.ListarVisitasPorSocio;

namespace Oper.Admision.Application.UseCases.Visitas.ListarVisitasPorSocio
{
    public class ListarVisitasPorSocioUseCase
    {
        private readonly IVisitaRepository _visitaRepository;
        private readonly IMapper _mapper;

        public ListarVisitasPorSocioUseCase(IVisitaRepository visitaRepository, IMapper mapper)
        {
            _visitaRepository = visitaRepository;
            _mapper = mapper;
        }

        public async Task<List<ListarVisitasPorSocioResponse>> EjecutarAsync(int socioId)
        {
            var visitas = await _visitaRepository.ObtenerPorSocioIdAsync(socioId);
            return _mapper.Map<List<ListarVisitasPorSocioResponse>>(visitas);
        }
    }
}
using AutoMapper;
using Oper.Admision.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.ObtenerVisitasPorFecha
{
    public class ObtenerVisitasPorFechaUseCase
    {
        private readonly IVisitaRepository _visitaRepository;
        private readonly IMapper _mapper;
        public ObtenerVisitasPorFechaUseCase(IVisitaRepository visitaRepository, IMapper mapper)
        {
            _visitaRepository = visitaRepository;
            _mapper = mapper;
        }
        public async Task<List<ObtenerVisitasPorFechaResponse>> EjecutarAsync(ObtenerVisitasPorFechaInput input)
        {
            var visitas = await _visitaRepository.ObtenerPorFechaAsync(input.Fecha);
            return _mapper.Map<List<ObtenerVisitasPorFechaResponse>>(visitas);
        }
    }
}

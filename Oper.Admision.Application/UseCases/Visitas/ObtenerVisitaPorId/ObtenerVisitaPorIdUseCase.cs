using AutoMapper;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.ObtenerVisitaPorId
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
            Visita? visita = await _visitaRepository.ObtenerPorIdAsync(input.Id);
            if (visita == null)
                return null;
            return _mapper.Map<ObtenerVisitaPorIdResponse>(visita);
        }
    }
}

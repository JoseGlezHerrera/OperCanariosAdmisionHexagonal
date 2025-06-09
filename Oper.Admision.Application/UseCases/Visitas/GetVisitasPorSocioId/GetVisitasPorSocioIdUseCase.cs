using AutoMapper;
using Oper.Admision.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.GetVisitasPorSocioId
{
    public class GetVisitasPorSocioIdUseCase
    {
        private readonly IVisitaRepository _repository;
        private readonly IMapper _mapper;
        public GetVisitasPorSocioIdUseCase(IVisitaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetVisitasPorSocioIdOutput>> Execute(GetVisitasPorSocioIdInput input)
        {
            var visitas = await _repository.ObtenerPorSocioIdAsync(input.SocioId);
            if (visitas == null || !visitas.Any())
                throw new Exception("No se encontraron visitas para el socio especificado.");
            var output = _mapper.Map<List<GetVisitasPorSocioIdOutput>>(visitas);
            return output;
        }
    }
}

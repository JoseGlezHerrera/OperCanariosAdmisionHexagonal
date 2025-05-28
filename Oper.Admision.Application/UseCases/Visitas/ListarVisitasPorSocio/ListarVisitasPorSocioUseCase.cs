using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.ListarVisitasPorSocio
{
    public class ListarVisitasPorSocioUseCase
    {
        private readonly IVisitaRepository _visitaRepository;
        public ListarVisitasPorSocioUseCase(IVisitaRepository visitaRepository)
        {
            _visitaRepository = visitaRepository ?? throw new ArgumentNullException(nameof(visitaRepository));
        }
        public async Task<List<Visita>>EjecutarAsync (ListarVisitasPorSocioInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "El input no puede ser nulo.");
            }
            return await _visitaRepository.ObtenerPorSocioIdAsync(input.SocioId);
        }
    }
}

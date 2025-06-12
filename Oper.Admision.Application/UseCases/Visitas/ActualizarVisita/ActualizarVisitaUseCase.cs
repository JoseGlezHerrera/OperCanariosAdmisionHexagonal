using Oper.Admision.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.ActualizarVisita
{
    public class ActualizarVisitaUseCase
    {
        private readonly IVisitaRepository _visitaRepository;
        public ActualizarVisitaUseCase(IVisitaRepository visitarepository)
        {
            _visitaRepository = visitarepository;
        }
        public async Task EjecutarAsync(ActualizarVisitaInput input)
        {
            var visita = await _visitaRepository.ObtenerPorIdAsync(input.IdVisita);
            if (visita == null)
            {
                throw new InvalidOperationException("La visita no existe.");
            }
            visita.fecha_hora = input.fecha;
            visita.id_sesion = input.IdSesion;
            visita.motivo = input.Motivo;
            await _visitaRepository.ActualizarAsync(visita);
        }
    }
}

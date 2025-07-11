﻿using Oper.Admision.Domain.IRepositories;

namespace Oper.Admision.Application.UseCases.Visita.EliminarVisita
{
    public class EliminarVisitaUseCase
    {
        private readonly IVisitaRepository _visitaRepository;

        public EliminarVisitaUseCase(IVisitaRepository visitaRepository)
        {
            _visitaRepository = visitaRepository;
        }

        public async Task<string> EjecutarAsync(EliminarVisitaInput input)
        {
            var resultado = await _visitaRepository.EliminarAsync(input.Id);

            if (resultado > 0)
                return $"Visita {input.Id} eliminada correctamente.";
            else
                return $"No se encontró ninguna visita con ID {input.Id}.";
        }
        public async Task Handle(int visitaId)
        {
            var visita = await _visitaRepository.GetByIdAsync(visitaId);
            if (visita == null)
                throw new InvalidOperationException("La visita no existe");
            await _visitaRepository.DeleteAsync(visitaId);
        }
    }
}
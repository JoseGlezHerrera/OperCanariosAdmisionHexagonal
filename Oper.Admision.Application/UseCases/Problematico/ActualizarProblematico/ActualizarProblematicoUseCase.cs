using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Problematico.ActualizarProblematico
{
    public class ActualizarProblematicoUseCase
    {
        private readonly IProblematicoRepository _repo;
        public ActualizarProblematicoUseCase(IProblematicoRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(ActualizarProblematicoInput input)
        {
            var entity = await _repo.GetByIdAsync(input.Id);
            if (entity is null) return false;
            entity.regla = input.Tipo;
            entity.comentario = input.Observaciones;
            await _repo.UpdateAsync(entity);
            return true;
        }
    }
}

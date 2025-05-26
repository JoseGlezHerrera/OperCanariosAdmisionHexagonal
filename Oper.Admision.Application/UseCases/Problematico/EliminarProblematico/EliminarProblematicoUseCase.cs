using Oper.Admision.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Problematico.EliminarProblematico
{
    public class EliminarProblematicoUseCase
    {
        private readonly IProblematicoRepository _repo;
        public EliminarProblematicoUseCase(IProblematicoRepository repo)
        {
            _repo = repo;
        }
        public async Task <bool> Handle (EliminarProblematicoInput input)
        {
            var problematico = await _repo.GetByIdAsync(input.Id);
            if (problematico is null) return false;
            await _repo.EliminarAsync(problematico);
            return true;
        }
    }
}

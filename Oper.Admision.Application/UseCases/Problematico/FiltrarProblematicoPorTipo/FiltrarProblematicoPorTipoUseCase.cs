using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Problematico.FiltrarProblematicoPorTipo
{
    public class FiltrarProblematicoPorTipoUseCase
    {
        private readonly IProblematicoRepository _repo;
        public FiltrarProblematicoPorTipoUseCase(IProblematicoRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ProblematicoVista>>Handle (FiltrarProblematicoPorTipoInput input)
        {
            return await _repo.FiltrarPorTipoAsync(input.Tipo);
        }
    }
}

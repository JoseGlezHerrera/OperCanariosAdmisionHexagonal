using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using Oper.Admision.Application.Exceptions;
using System.Collections.Generic;
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

        public async Task<List<ProblematicoVista>> Handle(FiltrarProblematicoPorTipoInput input)
        {
            var resultados = await _repo.FiltrarPorTipoAsync(input.Tipo);

            if (resultados == null || resultados.Count == 0)
                throw new ArgumentInputException($"No se encontraron registros para el tipo: '{input.Tipo}'.");

            return resultados;
        }
    }
}
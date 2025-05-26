using AutoMapper;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UsesCases.Problematicos.ObtenerProblematicoID
{
    public class ObtenerProblematicoPorIdUseCase
    {
        private readonly IProblematicoRepository _repo;
        private readonly IMapper _mapper;
        public ObtenerProblematicoPorIdUseCase(IProblematicoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ObtenerProblematicoResponse?> Handle(ObtenerProblematicoPorIdInput input)
        {
            var entity = await _repo.GetByIdAsync(input.Id);
            return entity is not null
                ? _mapper.Map<Problematico, ObtenerProblematicoResponse>(entity)
                : null;
        }
    }
}

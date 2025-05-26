using Microsoft.Extensions.Logging;
using Oper.Admision.Domain.IRepositories;

namespace Oper.Admision.Application.UseCases.Rol.GetTodos
{
    public class GetTodosUseCase
    {
        private readonly IRolRepository _rolRepository;
        private readonly ILogger<GetTodosUseCase> _logger;

        public GetTodosUseCase(IRolRepository rolRepository, ILogger<GetTodosUseCase> logger)
        {
            this._rolRepository = rolRepository;
            this._logger = logger;
        }
        public ICollection<GetTodosOutput> Execute()
        {
            var entidades = this._rolRepository.GetAll();
            return this.BuildOutPut(entidades);
        }

        private ICollection<GetTodosOutput> BuildOutPut(ICollection<Domain.Models.Rol> entidades)
        {
            var output = new List<GetTodosOutput>();
            foreach (var rol in entidades)
                output.Add(new GetTodosOutput() { RolId = rol.RolId, Nombre = rol.Nombre });
            return output;

        }
    }
}

using AutoMapper;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Microsoft.Extensions.Logging;

namespace Oper.Admision.Application.UseCases.Usuarios.GetTodos
{
    /// <summary>
    /// Caso de uso para dar de baja el usuario. O volver a dar de alta.
    /// </summary>
    public class GetTodosUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<GetTodosUsuarioUseCase> _logger;
        public GetTodosUsuarioUseCase(IMapper mapper, IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<GetTodosUsuarioUseCase> logger)
        {
            this._uow = uow;
            this._usuarioRepository = usuarioRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        public ICollection<GetTodosUsuarioOutput> Execute()
        {
            var entidades = this._usuarioRepository.GetAll();
            this._logger.LogInformation($"GetTodos Usuarios- Nº: {entidades.Count}");
            return this.BuildOutPut(entidades);
        }

        private ICollection<GetTodosUsuarioOutput> BuildOutPut(ICollection<Domain.Models.Usuario> usuarios)
        {
            var resultado = this._mapper.Map<ICollection<Domain.Models.Usuario>, ICollection<GetTodosUsuarioOutput>>(usuarios);
            return resultado;
        }
    }
}

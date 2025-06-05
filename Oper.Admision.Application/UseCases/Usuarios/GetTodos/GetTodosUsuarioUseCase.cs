using AutoMapper;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Usuarios.GetTodos
{
    public class GetTodosUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<GetTodosUsuarioUseCase> _logger;

        public GetTodosUsuarioUseCase(IMapper mapper, IGestionUOW uow, IUsuarioRepository usuarioRepository, ILogger<GetTodosUsuarioUseCase> logger)
        {
            _mapper = mapper;
            _uow = uow;
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        public async Task<List<GetTodosUsuarioOutput>> Execute(GetTodosUsuarioInput input)
        {
            var usuarios = _usuarioRepository.GetAll();
            _logger.LogInformation($"Usuarios encontrados: {usuarios.Count}");
            return _mapper.Map<List<GetTodosUsuarioOutput>>(usuarios);
        }
    }
}
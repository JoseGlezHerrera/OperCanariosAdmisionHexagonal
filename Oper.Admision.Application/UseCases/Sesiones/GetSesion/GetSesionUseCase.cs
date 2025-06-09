using AutoMapper;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Application.UseCases.Sesiones.GetSesion;

namespace Oper.Admision.Application.UseCases.Sesiones.GetSesion
{
    public class GetSesionUseCase
    {
        private readonly ISesionRepository _repository;
        private readonly IMapper _mapper;

        public GetSesionUseCase(ISesionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<GetSesionOutput> Execute(GetSesionInput input)
        {
            var sesion = _repository.Get(1);

            if (sesion == null)
                throw new Exception("Sesión no encontrada.");

            var output = _mapper.Map<GetSesionOutput>(sesion);
            return Task.FromResult(output);
        }
    }
}
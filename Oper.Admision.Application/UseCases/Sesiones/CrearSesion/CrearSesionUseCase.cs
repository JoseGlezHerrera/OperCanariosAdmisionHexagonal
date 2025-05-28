using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Application.UseCases.Sesiones.CrearSesion
{
    public class CrearSesionUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly ISesionRepository _sesionRepository;
        private readonly ILogger<CrearSesionUseCase> _logger;

        public CrearSesionUseCase(IMapper mapper, IGestionUOW uow, ISesionRepository sesionRepository, ILogger<CrearSesionUseCase> logger)
        {
            _mapper = mapper;
            _uow = uow;
            _sesionRepository = sesionRepository;
            _logger = logger;
        }

        private void Validate(CrearSesionInput input)
        {
            _logger.LogInformation("CrearSesionInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException("El input es nulo.");
            if (input.id_sede <= 0) throw new ArgumentInputException("id_sede inválido.");
        }

        public CrearSesionOutput Execute(CrearSesionInput input)
        {
            Validate(input);

            var sesion = _mapper.Map<Sesion>(input);

            _sesionRepository.Create(sesion);
            _uow.Save();

            return _mapper.Map<CrearSesionOutput>(sesion);
        }
    }
}

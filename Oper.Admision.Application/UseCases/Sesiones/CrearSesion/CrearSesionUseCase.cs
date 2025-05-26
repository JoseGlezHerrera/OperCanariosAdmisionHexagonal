using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (input == null) throw new ArgumentInputException(Mensaje.Sesion_Input);
            if (input.id_sesion == 0) throw new ArgumentInputException(Mensaje.Requerido("id_sesion"));
            
        }
        public CrearSesionOutput Execute(CrearSesionInput input)
        {
            Validate(input);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CrearSesionInput, Sesion>());
            var mapper = config.CreateMapper();
            var sesion = _mapper.Map<CrearSesionInput, Sesion>(input);
            sesion.fecha_hora = DateTime.Now;
            _sesionRepository.Create(sesion);
            _uow.Save();
            return BuildOutPut(sesion);
        }
        private CrearSesionOutput BuildOutPut(Sesion entidad)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Sesion, CrearSesionOutput>());
            var mapper = config.CreateMapper();
            var sesion = _mapper.Map<Sesion, CrearSesionOutput>(entidad);
            return sesion;
        }

    }
}

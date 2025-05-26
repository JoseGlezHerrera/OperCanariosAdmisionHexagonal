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

namespace Oper.Admision.Application.UseCases.Visitas.CrearVisita
{
    public class CrearVisitaUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IVisitaRepository _visitaRepository;
        private readonly ILogger<CrearVisitaUseCase> _logger;

        public CrearVisitaUseCase(IMapper mapper, IGestionUOW uow, IVisitaRepository visitaRepository, ILogger<CrearVisitaUseCase> logger)
        {
            _mapper = mapper;
            _uow = uow;
            _visitaRepository = visitaRepository;
            _logger = logger;
        } 
        private void Validate(CrearVisitaInput input)
        {
            _logger.LogInformation("CrearVisitaInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Visita_Input);
            if (input.id_visita == 0) throw new ArgumentInputException(Mensaje.Requerido("id_visita"));
            if (input.id_socio == 0) throw new ArgumentInputException(Mensaje.Requerido("id_socio"));
        }
        public CrearVisitaOutput Execute(CrearVisitaInput input)
        {
            Validate(input);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CrearVisitaInput, Visita>());
            var mapper = config.CreateMapper();
            var visita = _mapper.Map<CrearVisitaInput, Visita>(input);
            visita.fecha_hora = DateTime.Now;
            _visitaRepository.Create(visita);
            _uow.Save();
            return BuildOutPut(visita);
        }
        private CrearVisitaOutput BuildOutPut(Visita entidad)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Visita, CrearVisitaOutput>());
            var mapper = config.CreateMapper();
            var visita = _mapper.Map<Visita, CrearVisitaOutput>(entidad);
            return visita;
        }
    }
}

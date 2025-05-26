using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Application.UseCases.Usuarios.Crear;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using Oper.Admision.Domain.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.CrearSocio
{
    public class CrearSocioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly ISocioRepository _socioRepository;
        private readonly ILogger<CrearSocioUseCase> _logger;

        public CrearSocioUseCase(IMapper mapper, IGestionUOW uow, ISocioRepository socioRepository, ILogger<CrearSocioUseCase> logger)
        {
            _mapper = mapper;
            _uow = uow;
            _socioRepository = socioRepository;
            _logger = logger;

        }
        private void Validate(CrearSocioInput input)
        {
            _logger.LogInformation("CrearSocioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Socio_Input);
            if (_socioRepository.ExisteNombre(null, input.dni)) throw new ArgumentInputException(Mensaje.DNI_DUPLICADO(input.dni));

            if (string.IsNullOrEmpty(input.dni)) throw new ArgumentInputException(Mensaje.Requerido("dni"));
            if (input.id_socio == 0) throw new ArgumentInputException(Mensaje.Requerido("id_socio"));
            if (string.IsNullOrEmpty(input.nombre)) throw new ArgumentInputException(Mensaje.Requerido("nombre"));
            if (string.IsNullOrEmpty(input.calle)) throw new ArgumentInputException(Mensaje.Requerido("calle"));
            if (string.IsNullOrEmpty(input.dni)) throw new ArgumentInputException(Mensaje.Requerido("telefono"));
        }

        public CrearSocioOutput Execute(CrearSocioInput input)
        {
            Validate(input);
  

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CrearSocioInput, Socio>());
            var mapper = config.CreateMapper();
            var socio = _mapper.Map<CrearSocioInput, Socio>(input);
            socio.fecha_modificacion = DateTime.Now;
            var nuevaClave = GeneradorClaves.Token(6);
            _socioRepository.Create(socio);
            _uow.Save();
            return BuildOutPut(socio);
        }
        private CrearSocioOutput BuildOutPut(Socio entidad)
        {
            var resultado = _mapper.Map<Socio, CrearSocioOutput>(entidad);
            return resultado;
        }
    }
}
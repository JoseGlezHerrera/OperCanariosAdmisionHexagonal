using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using Oper.Admision.Domain.Seguridad;
using System;

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
            _logger.LogWarning("Valor recibido en input.sexo: '{Sexo}'", input.sexo);
            _logger.LogInformation("CrearSocioInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Socio_Input);
            if (_socioRepository.ExisteDni(input.dni)) throw new ArgumentInputException(Mensaje.DNI_DUPLICADO(input.dni));
            if (string.IsNullOrEmpty(input.dni)) throw new ArgumentInputException(Mensaje.Requerido("dni"));
            if (string.IsNullOrEmpty(input.nombre)) throw new ArgumentInputException(Mensaje.Requerido("nombre"));
            if (string.IsNullOrEmpty(input.calle)) throw new ArgumentInputException(Mensaje.Requerido("calle"));
            if (string.IsNullOrEmpty(input.telefono)) throw new ArgumentInputException(Mensaje.Requerido("telefono"));
            var sexoNormalizado = input.sexo?.Trim().ToLowerInvariant();
            if (sexoNormalizado != "masculino" && sexoNormalizado != "femenino") throw new ArgumentInputException("El campo 'sexo' solo admite los valores 'Masculino' o 'Femenino'");
            if (input.fecha_nacimiento > DateTime.Now.AddYears(-18)) throw new ArgumentInputException("El socio debe ser mayor de edad (18 años) para poder ser registrado");
        }

        public CrearSocioOutput Execute(CrearSocioInput input)
        {
            Validate(input);
            var socio = _mapper.Map<Socio>(input);
            var sexoNormalizado = input.sexo?.Trim().ToLowerInvariant();

            if (sexoNormalizado != "masculino" && sexoNormalizado != "femenino")
            {
                throw new ArgumentInputException("El campo 'sexo' solo admite los valores 'Masculino' o 'Femenino'");
            }
            socio.sexo = sexoNormalizado switch
            {
                "masculino" => true,
                "femenino" => false,
                _ => null
            };

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
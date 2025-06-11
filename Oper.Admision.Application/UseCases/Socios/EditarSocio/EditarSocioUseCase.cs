using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Application.UseCases.Socios.EditarUsuario;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.EditarSocio
{
    public class EditarSocioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly ISocioRepository _socioRepository;
        private readonly ILogger<EditarSocioUseCase> _logger;

        public EditarSocioUseCase(IMapper mapper, IGestionUOW uow, ISocioRepository socioRepository, ILogger<EditarSocioUseCase> logger)
        {
            this._mapper = mapper;
            this._uow = uow;
            this._socioRepository = socioRepository;
            this._logger = logger;
        }

        private void Validate(EditarSocioInput input)
        {
            _logger.LogInformation("EditarSocioInput es: {@input}", input);
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (string.IsNullOrEmpty(input.dni)) throw new ArgumentNullException(nameof(input.dni));
            if (string.IsNullOrEmpty(input.nombre)) throw new ArgumentNullException(nameof(input.nombre));
            if (input.id_socio <= 0) throw new ArgumentOutOfRangeException(nameof(input.id_socio), "El id_socio debe ser mayor que 0.");
            if (string.IsNullOrEmpty(input.apel1)) throw new ArgumentNullException(nameof(input.apel1));
            if (string.IsNullOrEmpty(input.apel2)) throw new ArgumentNullException(nameof(input.apel2));
            if (_socioRepository.ExisteDniParaOtroSocio(input.id_socio, input.dni)) throw new ArgumentInputException(Mensaje.DNI_DUPLICADO(input.dni));
            var sexoNormalizado = input.sexo?.Trim().ToLowerInvariant();
            if (sexoNormalizado != "masculino" && sexoNormalizado != "femenino")
                throw new ArgumentInputException("El campo 'sexo' solo admite los valores 'Masculino' o 'Femenino'");

        }
        public EditarSocioOutput Execute(EditarSocioInput input)
        {
            var socio = this._socioRepository.Get(input.id_socio);
            if (socio == null)
                throw new KeyNotFoundException($"No existe el socio con id {input.id_socio}");
            Validate(input);
            socio.dni = input.dni;
            socio.nombre = input.nombre;
            socio.apel1 = input.apel1;
            socio.apel2 = input.apel2;
            socio.sexo = input.sexo?.Trim().ToLowerInvariant() == "masculino" ? true
                        : input.sexo?.Trim().ToLowerInvariant() == "femenino" ? false
                        : (bool?)null;

            this._socioRepository.Update(socio);
            this._uow.Save();

            var output = BuildOutPut(socio);
            output.Mensaje = $"Socio {socio.id_socio} editado correctamente.";
            return output;
        }
        private EditarSocioOutput BuildOutPut(Socio entidad)
        {
            var resultado = this._mapper.Map<Socio, EditarSocioOutput>(entidad);
            return resultado;
        }

    }
}

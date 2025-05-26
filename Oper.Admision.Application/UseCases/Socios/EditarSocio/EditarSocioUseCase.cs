using AutoMapper;
using Microsoft.Extensions.Logging;
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
        }
        public EditarSocioOutput Execute(EditarSocioInput input)
        { 
            Validate(input);
            var socio = this._socioRepository.Get(input.id_socio);
            socio.dni = input.dni;
            socio.nombre = input.nombre;
            socio.apel1 = input.apel1;
            socio.id_socio = input.id_socio;
            socio.apel2 = input.apel2;

            this._socioRepository.Update(socio);
            this._uow.Save();
            return this.BuildOutPut(socio);
        }
        private EditarSocioOutput BuildOutPut(Socio entidad)
        {
            var resultado = this._mapper.Map<Socio, EditarSocioOutput>(entidad);
            return resultado;
        }

    }
}

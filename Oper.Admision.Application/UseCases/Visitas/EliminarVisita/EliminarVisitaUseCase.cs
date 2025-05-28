using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.EliminarVisita
{
    public class EliminarVisitaUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IVisitaRepository _visitaRepository;
        private readonly ILogger<EliminarVisitaUseCase> _logger;

        public EliminarVisitaUseCase(IGestionUOW uow, IVisitaRepository visitaRepository, ILogger<EliminarVisitaUseCase> logger)
        {
            this._uow = uow;
            this._visitaRepository = visitaRepository;
            this._logger = logger;
        }

        private void Validate(EliminarVisitaInput input)
        {
            this._logger.LogInformation("EliminarVisitaInput es: {@input}", input);
            if (input == null) throw new ArgumentInputException(Mensaje.Usuario_Input);
            if (input.id_visita == 0) throw new ArgumentInputException(Mensaje.Requerido("id_visita"));
        }
    }
}

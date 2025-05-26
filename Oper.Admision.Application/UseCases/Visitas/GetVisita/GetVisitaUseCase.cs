using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.GetVisita
{
    public class GetVisitaUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly IVisitaRepository _VisitaRepository;
        private readonly ILogger<GetVisitaUseCase> _logger;

        public GetVisitaUseCase(IMapper mapper, IGestionUOW uow, IVisitaRepository VisitaRepository, ILogger<GetVisitaUseCase> logger)
        {
            this._uow = uow;
            this._VisitaRepository = VisitaRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        public ICollection<GetVisitaOutPut> Execute()
        {
            var entidades = this._VisitaRepository.GetAll();
            this._logger.LogInformation($"Get Visitas- Nº: {entidades.Count}");
            return this.BuildOutPut(entidades);
        }

        private ICollection<GetVisitaOutPut> BuildOutPut(ICollection<Domain.Models.Visita> visitas)
        {
            var resultado = this._mapper.Map<ICollection<Domain.Models.Visita>, ICollection<GetVisitaOutPut>>(visitas);
            return resultado;
        }
    }
}

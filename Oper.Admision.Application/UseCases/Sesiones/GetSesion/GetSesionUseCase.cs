using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Sesiones.GetSesion
{
    public class GetSesionUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly ISesionRepository _SesionRepository;
        private readonly ILogger<GetSesionUseCase> _logger;

        public GetSesionUseCase(IMapper mapper, IGestionUOW uow, ISesionRepository SesionRepository, ILogger<GetSesionUseCase> logger)
        {
            this._uow = uow;
            this._SesionRepository = SesionRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        public ICollection<GetSesionOutput> Execute()
        {
            var entidades = this._SesionRepository.GetAll();
            this._logger.LogInformation($"Get Sesion- Nº: {entidades.Count}");
            return this.BuildOutPut(entidades);
        }

        private ICollection<GetSesionOutput> BuildOutPut(ICollection<Domain.Models.Sesion> sesions)
        {
            var resultado = this._mapper.Map<ICollection<Domain.Models.Sesion>, ICollection<GetSesionOutput>>(sesions);
            return resultado;
        }
    }
}

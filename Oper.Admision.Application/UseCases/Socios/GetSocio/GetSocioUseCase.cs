using AutoMapper;
using Microsoft.Extensions.Logging;
using Oper.Admision.Domain;
using Oper.Admision.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.GetSocio
{
    public class GetSocioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;
        private readonly ISocioRepository _SocioRepository;
        private readonly ILogger<GetSocioUseCase> _logger;

        public GetSocioUseCase(IMapper mapper, IGestionUOW uow, ISocioRepository SocioRepository, ILogger<GetSocioUseCase> logger)
        {
            this._uow = uow;
            this._SocioRepository = SocioRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        public async Task EjecutarAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<GetSocioOutput> Execute()
        {
            var entidades = this._SocioRepository.GetAll();
            this._logger.LogInformation($"Get Socios- Nº: {entidades.Count}");
            return this.BuildOutPut(entidades);
        }
        private ICollection<GetSocioOutput> BuildOutPut(ICollection<Domain.Models.Socio> socios)
        {
            var resultado = this._mapper.Map<ICollection<Domain.Models.Socio>, ICollection<GetSocioOutput>>(socios);
            return resultado;
        }
    }
}

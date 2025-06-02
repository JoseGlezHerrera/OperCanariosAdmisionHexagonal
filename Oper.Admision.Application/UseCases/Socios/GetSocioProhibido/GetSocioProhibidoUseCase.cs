using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.GetSocioProhibido
{
    public class GetSocioProhibidoUseCase
    {
        private readonly ISocioRepository _socioRepository;
        public GetSocioProhibidoUseCase(ISocioRepository socioRepository)
        {
            _socioRepository = socioRepository ?? throw new ArgumentNullException(nameof(socioRepository));
        }
        public List<Socio> Execute()
        {
            return _socioRepository.ObtenerSociosProhibidos();
        }
    }
}
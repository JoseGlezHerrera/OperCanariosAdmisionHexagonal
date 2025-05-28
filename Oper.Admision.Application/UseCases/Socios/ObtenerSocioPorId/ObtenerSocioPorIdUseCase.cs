using Oper.Admision.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.ObtenerSocioPorId
{
    public class ObtenerSocioPorIdUseCase
    {
        private readonly ISocioRepository _repository;
        public ObtenerSocioPorIdUseCase(ISocioRepository repository)
        {
            _repository = repository;
        }
        public async Task<Domain.Models.Socio?> EjecutarAsync (ObtenerSocioPorIdInput input)
        {
            return await _repository.ObtenerPorIdAsync(input.Id);
        }
    }
}

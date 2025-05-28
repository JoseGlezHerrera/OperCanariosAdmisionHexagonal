using Oper.Admision.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.EliminarSocio
{
    public class EliminarSocioUseCase
    {
        private readonly ISocioRepository _repository;
        public EliminarSocioUseCase(ISocioRepository repository)
        {
            _repository = repository;
        }
        public async Task EjecutarAsync (EliminarSocioInput input)
        {
            await _repository.EliminarAsync(input.Id);
        }
    }
}

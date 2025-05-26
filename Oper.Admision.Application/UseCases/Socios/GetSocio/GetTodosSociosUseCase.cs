using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios
{
    public class GetTodosSociosUseCase
    {
        private readonly ISocioRepository _socioRepository;
        public GetTodosSociosUseCase(ISocioRepository socioRepository)
        {
            _socioRepository = socioRepository;
        }
        public async Task<List<Socio>>EjecutarAsync()
        {
            return await _socioRepository.ObtenerTodosAsync();
        }
    }
}

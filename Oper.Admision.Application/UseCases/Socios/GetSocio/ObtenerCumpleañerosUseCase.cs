using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.GetSocio
{
    public class ObtenerCumpleañerosUseCase
    {
        private readonly ISocioRepository _repo;

        public ObtenerCumpleañerosUseCase(ISocioRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Socio>> EjecutarAsync()
        {
            return await _repo.ObtenerCumpleañerosDeHoyAsync();
        }
    }
}

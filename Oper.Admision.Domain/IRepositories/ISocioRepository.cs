using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.IRepositories
{
    public interface ISocioRepository
    {
        void Create(Socio socio);
        void Update(Socio socio);
        void Delete(int id_socio);
        Socio Get(int id_socio);
        ICollection<Socio> GetAll();
        bool ExisteNombre(int? id_socio, string nombre);
        Task<List<Socio>> ObtenerCumpleañerosDeHoyAsync();
        Task<List<Socio>> ObtenerTodosAsync();
        Task<Socio> GetByDniAsync(string dni);
        Task EliminarAsync(int id);
        Task<Socio?> ObtenerPorIdAsync(int id);
        List<Socio> ObtenerSociosProhibidos();
        bool ExisteDni(string dni);
        bool ExisteDniParaOtroSocio(int id_socio, string dni);
        Task<bool> ExisteAsync(int id);

    }
}

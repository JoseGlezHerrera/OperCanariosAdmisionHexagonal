using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.IRepositories
{
    public interface IVisitaRepository
    {
        void Create(Visita visita);
        void Update(Visita visita);
        void Delete(int id_visita);
        Socio Get(int id_visita);
        ICollection<Visita> GetAll();

    }
}

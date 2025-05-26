using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.IRepositories
{
    public interface ISesionRepository
    {
        void Create(Sesion sesion);
        void Update(Sesion sesion);
        void Delete(int id_sesion);
        Sesion Get(int id_sesion);
        ICollection<Sesion> GetAll();
    }
}

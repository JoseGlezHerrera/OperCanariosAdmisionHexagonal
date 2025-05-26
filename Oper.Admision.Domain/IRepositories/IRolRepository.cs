
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Domain.IRepositories
{
    public interface IRolRepository
    {
        ICollection<Rol> GetAll();
        int GetId(int usuarioId);
    }
}

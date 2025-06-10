using Oper.Admision.Domain.Models;

namespace Oper.Admision.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        void Create(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int usuarioId);
        Usuario Get(int usuarioId);
        Usuario Get(string email);
        ICollection<Usuario> GetAll();
        bool ExisteNombre(string nombre);
        bool ExisteNombre(int? usuarioId, string nombre);
        Usuario Login(string username, string password);
        Task<Usuario?> ObtenerPorNombreAsync(string nombreUsuario);
        bool ExisteDni(string dni);
        bool ExisteDniParaOtroUsuario(int usuarioId, string dni);
    }
}

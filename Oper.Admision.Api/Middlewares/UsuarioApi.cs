namespace Oper.Admision.Api
{
    public interface IUsuarioApi
    {
        int UsuarioId { get; }
        void Insertar(int usuarioId);
    }
    public class UsuarioApi : IUsuarioApi
    {
        public int UsuarioId { get; private set; }

        public UsuarioApi()
        {
            this.UsuarioId = 1;
        }

        public void Insertar(int usuarioId)
        {
            this.UsuarioId = usuarioId;
        }
    }
}

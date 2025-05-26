namespace Oper.Admision.Application.UseCases.Usuarios.Editar
{
    public class EditarUsuarioInput
    {
        public int UsuarioId { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }

        public DateTime? FechaBaja { get; set; }
    }
}
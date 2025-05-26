namespace Oper.Admision.Application.UseCases.Usuarios.Editar
{
    public class EditarUsuarioOutput
    {
        public int UsuarioId { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        
        public DateTime FechaAlta { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int RolId { get; set; }
    }
}
namespace Oper.Admision.Application.UseCases.Usuarios.Crear
{
    public class CrearUsuarioInput
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
        public string Password { get; set; }
    }
}
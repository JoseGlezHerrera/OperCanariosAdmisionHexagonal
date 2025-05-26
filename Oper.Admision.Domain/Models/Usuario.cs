using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Oper.Admision.Domain.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int UsuarioId { get; set; }

        public string Password { get; set; }  
        public string Nombre { get; set; }    
        public string? Alias { get; set; }     
        public string? Email { get; set; }    
        public string? Dni { get; set; }      

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("fecha_update")]
        public DateTime FechaActualizacion { get; set; }

        [Column("fecha_baja")]
        public DateTime? FechaBaja { get; set; }

        public bool Bloqueado { get; set; }
        public bool Eliminado { get; set; }

        [ForeignKey("Rol")]
        [Column("id_rol")]
        public int? RolId { get; set; }

        public virtual Rol Rol { get; set; }

        public string Notificacion(string nuevaClave)
        {
            string resultado = $"Se establece una nueva contraseña para el usuario {this.Nombre} es: {nuevaClave}";
            StringBuilder st = new StringBuilder();
            st.AppendFormat("<p>Se establece una nueva contraseña para el usuario <b>{0}</b></p>", this.Nombre);
            st.AppendFormat("<p>La nueva clave es: <b>{0}</b></p>", nuevaClave);
            st.AppendFormat("<p>No contestes a este correo, pues se envío desde una dirección no habilitada para la recepción de mensajes. Si lo deseas, puedes ponerte en contacto con Dto. Informática a través del email informatica@opercanarios.com</p>", nuevaClave);
            return st.ToString();
        }
    }
}

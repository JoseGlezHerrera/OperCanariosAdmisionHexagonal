using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.Models
{
    [Table("roles")]
    public class Rol
    {
        [Column("id_rol")]
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    }
}

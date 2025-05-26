namespace Oper.Admision.Domain.Models
{
    public interface IConfigCorreo
    {
        public string Servidor { get; set; }
        public int Puerto { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public string Destinatarios { get; set; }
    }
}

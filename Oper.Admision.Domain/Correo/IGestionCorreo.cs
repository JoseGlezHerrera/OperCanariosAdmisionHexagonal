
namespace Oper.Admision.Domain.Correo
{
    public interface IGestionCorreo
    {
        string[] Destinatarios { get; set; }

        string Enviar(string cabecera, string mensaje);

        string Enviar(string cabecera, string mensaje, string destinatario);
    }
}

namespace Oper.Admision.Api.UseCases.Visitas.CrearVisita
{
    public class CrearVisitaRequest
    {
        public int id_visita { get; set; }

        public int id_socio { get; set; }
        public int? id_sesion { get; set; }
        public int? id_sede { get; set; }

    }
}

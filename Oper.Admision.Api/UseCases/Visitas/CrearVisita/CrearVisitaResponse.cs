namespace Oper.Admision.Api.UseCases.Visitas.CrearVisita
{
    internal class CrearVisitaResponse
    {
        public int id_visita { get; set; }

        public int id_socio { get; set; }
        public int? id_sesion { get; set; }
        public int? id_sede { get; set; }
        public DateTime fecha_hora { get; set; }

        public CrearVisitaResponse()
        {
            this.fecha_hora = DateTime.Now;
        }

    }
}

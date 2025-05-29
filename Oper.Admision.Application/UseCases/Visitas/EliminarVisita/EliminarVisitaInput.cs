namespace Oper.Admision.Application.UseCases.Visita.EliminarVisita
{
    public class EliminarVisitaInput
    {
        public int Id { get; }

        public EliminarVisitaInput(int id)
        {
            Id = id;
        }
    }
}
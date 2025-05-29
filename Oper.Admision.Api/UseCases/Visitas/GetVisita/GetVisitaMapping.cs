using AutoMapper;

using Oper.Admision.Application.UseCases.Visitas.GetVisita;
using Oper.Admision.Domain.Models;

public class GetVisitaMapping : Profile
{
    public GetVisitaMapping()
    {
        CreateMap<Visita, GetVisitaOutPut>();
    }
}

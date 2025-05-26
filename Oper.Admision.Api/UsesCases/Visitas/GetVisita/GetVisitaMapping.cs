using AutoMapper;
using Oper.Admision.Application.UseCases.Visitas.GetVisita;

namespace Oper.Admision.Api.UsesCases.Visitas.GetVisita
{
    public class GetVisitaMapping : Profile
    {
      
            public GetVisitaMapping()
            {
                CreateMap<GetVisitaOutPut, GetVisitaResponse>();
            }
        
    }
    
}

using AutoMapper;
using Oper.Admision.Application.UseCases.Visitas.CrearVisita;

namespace Oper.Admision.Api.UseCases.Visitas.CrearVisita
{
    public class CrearVisitaMapping : Profile
    {
        public CrearVisitaMapping()
        {
            CreateMap<CrearVisitaRequest, CrearVisitaInput>();
            CreateMap<CrearVisitaOutput, CrearVisitaResponse>();
        }
    }
    
}

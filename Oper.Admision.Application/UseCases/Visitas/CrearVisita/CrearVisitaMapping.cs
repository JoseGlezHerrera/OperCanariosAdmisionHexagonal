using AutoMapper;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Application.UseCases.Visitas.CrearVisita
{
    public class CrearVisitaMapping : Profile
    {
        public CrearVisitaMapping()
        {
            CreateMap< Visita, CrearVisitaOutput>();
            CreateMap<CrearVisitaOutput , Visita >();
            CreateMap<CrearVisitaInput , Visita>();
        }
    }
    
}

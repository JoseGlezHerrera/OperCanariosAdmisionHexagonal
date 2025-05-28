using AutoMapper;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Visitas.ListarVisitasPorSocio
{
    public class ListarVisitasPorSocioMapping : Profile
    {
        public ListarVisitasPorSocioMapping()
        {
            CreateMap<Visita, ListarVisitasPorSocioResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id_visita))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.fecha_hora))
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.motivo));
        }
    }
}

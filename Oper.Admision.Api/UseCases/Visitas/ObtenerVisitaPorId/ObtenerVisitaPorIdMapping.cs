using AutoMapper;
using Oper.Admision.Application.UseCases.Visitas.ObtenerVisitaPorId;

namespace Oper.Admision.Api.UseCases.Visitas.ObtenerVisitaPorId
{
    public class ObtenerVisitaPorIdMapping : Profile
    {
        public ObtenerVisitaPorIdMapping()
        {
            CreateMap<Oper.Admision.Domain.Models.Visita, ObtenerVisitaPorIdResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id_visita))
                .ForMember(dest => dest.id_socio, opt => opt.MapFrom(src => src.id_socio))
                .ForMember(dest => dest.fecha_hora, opt => opt.MapFrom(src => src.fecha_hora))
                .ForMember(dest => dest.motivo, opt => opt.MapFrom(src => src.motivo));
        }
    }
}

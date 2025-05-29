using AutoMapper;
using Oper.Admision.Application.UseCases.Visitas.ObtenerVisitasPorFecha;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Visitas.ObtenerVisitasPorFecha
{
    public class ObtenerVisitasPorFechaMapping : Profile
    {
        public ObtenerVisitasPorFechaMapping()
        {
            CreateMap<Visita, ObtenerVisitasPorFechaResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id_visita))
                .ForMember(dest => dest.IdSocio, opt => opt.MapFrom(src => src.id_socio))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.fecha_hora))
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.motivo));
        }
    }
}

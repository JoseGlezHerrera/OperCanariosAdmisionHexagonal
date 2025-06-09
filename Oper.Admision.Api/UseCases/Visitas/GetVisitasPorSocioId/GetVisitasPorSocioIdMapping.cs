using AutoMapper;
using Oper.Admision.Application.UseCases.Visitas.GetVisitasPorSocioId;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Visitas.GetVisitasPorSocioId
{
    public class GetVisitasPorSocioIdMapping : Profile
    {
        public GetVisitasPorSocioIdMapping()
        {
            CreateMap<GetVisitasPorSocioIdOutput, GetVisitasPorSocioIdResponse>();
            CreateMap<Visita, GetVisitasPorSocioIdOutput>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id_visita))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.fecha_hora))
                .ForMember(dest => dest.SocioId, opt => opt.MapFrom(src => src.id_socio));
        }
    }
}
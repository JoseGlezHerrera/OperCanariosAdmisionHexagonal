using AutoMapper;
using Oper.Admision.Application.UseCases.Visitas.CrearVisita;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Visitas.CrearVisita
{
    public class CrearVisitaMapping : Profile
    {
        public CrearVisitaMapping()
        {
            CreateMap<CrearVisitaInput, Visita>()
                .ForMember(dest => dest.fecha_hora, opt => opt.MapFrom(src => src.Fecha))
                .ForMember(dest => dest.id_sede, opt => opt.MapFrom(src => src.IdSede))
                .ForMember(dest => dest.id_sesion, opt => opt.MapFrom(src => src.IdSesion))
                .ForMember(dest => dest.id_socio, opt => opt.MapFrom(src => src.SocioId))
                .ForMember(dest => dest.motivo, opt => opt.MapFrom(src => src.Motivo));

            CreateMap<Visita, CrearVisitaOutput>()
                .ForMember(dest => dest.id_visita, opt => opt.MapFrom(src => src.id_visita))
                .ForMember(dest => dest.id_socio, opt => opt.MapFrom(src => src.id_socio))
                .ForMember(dest => dest.id_sede, opt => opt.MapFrom(src => src.id_sede))
                .ForMember(dest => dest.id_sesion, opt => opt.MapFrom(src => src.id_sesion))
                .ForMember(dest => dest.fecha_hora, opt => opt.MapFrom(src => src.fecha_hora))
                .ForMember(dest => dest.motivo, opt => opt.MapFrom(src => src.motivo));


            CreateMap<CrearVisitaOutput, CrearVisitaResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id_visita))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.fecha_hora))
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.motivo))
                .ForMember(dest => dest.SocioId, opt => opt.MapFrom(src => src.id_socio));


        }
    }
}
using AutoMapper;
using Oper.Admision.Api.UsesCases.Problematicos.ObtenerProblematicoID;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Problematicos.ObtenerProblematicoID;

public static class ObtenerProblematicoMapping
{
    public static void Configure(IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<Problematico, ObtenerProblematicoResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id_problematicos))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.id_socio.ToString()))
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.regla))
            .ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.comentario));
    }
}
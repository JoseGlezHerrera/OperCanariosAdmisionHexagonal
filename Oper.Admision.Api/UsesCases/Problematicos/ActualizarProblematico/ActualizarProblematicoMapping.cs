using AutoMapper;
using Oper.Admision.Api.UseCases.Problematicos.ActualizarProblematico;
using Oper.Admision.Api.UsesCases.Problematicos.ActualizarProblematico;
using Oper.Admision.Application.UseCases.Problematico.ActualizarProblematico;

namespace Oper.Admision.Api.UseCases.Problematicos.ActualizarProblematico;

public static class ActualizarProblematicoMapping
{
    public static void Configure(IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<ActualizarProblematicoRequest, ActualizarProblematicoInput>()
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.Observaciones));
    }
}
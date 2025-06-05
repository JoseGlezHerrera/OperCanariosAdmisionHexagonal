using AutoMapper;
using Oper.Admision.Application.UseCases.Problematicos.CrearProblematico;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Problematicos.CrearProblematico;

public class CrearProblematicoMapping : Profile
{
    public CrearProblematicoMapping()
    {
        CreateMap<CrearProblematicoRequest, CrearProblematicoInput>();

        CreateMap<Problematico, CrearProblematicoOutput>()
            .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni))
            .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.fecha_crea ?? DateTime.UtcNow))
            .ForMember(dest => dest.Regla, opt => opt.MapFrom(src => src.regla))
            .ForMember(dest => dest.Comentario, opt => opt.MapFrom(src => src.comentario))
            .ForMember(dest => dest.Visible, opt => opt.MapFrom(src => src.visible))
            .ForMember(dest => dest.Conflictivo, opt => opt.MapFrom(src => src.conflictivo))
            .ForMember(dest => dest.ProhibidaEntrada, opt => opt.MapFrom(src => src.prohibida_entrada))
            .ForMember(dest => dest.Gobcan, opt => opt.MapFrom(src => src.gobcan))
            .ForMember(dest => dest.TipoProblematico, opt => opt.MapFrom(src =>
                src.conflictivo ? 3 :
                src.prohibida_entrada ? 2 :
                src.gobcan ? 1 : 0
            ));
        CreateMap<CrearProblematicoOutput, CrearProblematicoResponse>();
    }
}
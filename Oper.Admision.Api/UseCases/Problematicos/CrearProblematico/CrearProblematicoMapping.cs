using AutoMapper;
using Oper.Admision.Application.UseCases.Problematico.CrearProblematico;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Problematicos.CrearProblematico;

public class CrearProblematicoMapping : Profile
{
    public CrearProblematicoMapping()
    {
        CreateMap<CrearProblematicoRequest, CrearProblematicoInput>();

        CreateMap<Problematico, CrearProblematicoResponse>()
            .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.id_socio.ToString()))
            .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.fecha_crea ?? DateTime.MinValue))
            .ForMember(dest => dest.Regla, opt => opt.MapFrom(src => src.regla))
            .ForMember(dest => dest.Comentario, opt => opt.MapFrom(src => src.comentario))
            .ForMember(dest => dest.TipoProblematico, opt => opt.MapFrom(src =>
                src.conflictivo ? 3 :
                src.prohibida_entrada ? 2 :
                src.gobcan ? 1 : 0
            ));
    }
}
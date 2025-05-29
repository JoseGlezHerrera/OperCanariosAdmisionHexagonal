using AutoMapper;
using Oper.Admision.Api.UseCases.Socios.ObtenerSocioPorId;
using Oper.Admision.Domain.Models;

public class ObtenerSocioPorIdMapping : Profile
{
    public ObtenerSocioPorIdMapping()
    {
        CreateMap<Socio, ObtenerSocioPorIdResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id_socio))
            .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.nombre} {src.apel1}".Trim()))
            .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.dni));
    }
}
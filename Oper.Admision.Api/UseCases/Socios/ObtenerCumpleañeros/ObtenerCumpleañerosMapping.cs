using AutoMapper;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Socios.ObtenerCumpleañeros;

public class ObtenerCumpleañerosMapping : Profile
{
    public ObtenerCumpleañerosMapping()
    {
        CreateMap<Socio, ObtenerCumpleañerosResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id_socio))
            .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.nombre} {src.apel1}"))
            .ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.fecha_nacimiento));
    }
}
using AutoMapper;
using Oper.Admision.Application.UseCases.Socios.CrearSocio;
using Oper.Admision.Api.UseCases.Socios.CrearSocio;
using Oper.Admision.Domain.Models;

public class CrearSocioMapping : Profile
{
    public CrearSocioMapping()
    {
        CreateMap<CrearSocioRequest, CrearSocioInput>();

        CreateMap<CrearSocioInput, Socio>()
            .ForMember(dest => dest.fecha_nacimiento, opt => opt.MapFrom(src => src.fecha_nacimiento));

        CreateMap<Socio, CrearSocioOutput>();
    }
}


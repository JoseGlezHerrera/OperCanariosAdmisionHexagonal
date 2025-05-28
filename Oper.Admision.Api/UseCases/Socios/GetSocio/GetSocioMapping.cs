using AutoMapper;
using Oper.Admision.Application.UseCases.Socios.GetSocio;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Socios.GetSocio
{
    public class GetSocioMapping : Profile
    {
        public GetSocioMapping()
        {
            CreateMap<Socio, GetSocioOutput>()
                .ForMember(dest => dest.id_socio, opt => opt.MapFrom(src => src.id_socio))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => $"{src.nombre} {src.apel1}"));
        }
    }
}

using AutoMapper;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Socios.ObtenerSocioPorId
{
    public class ObtenerSocioPorIdMapping : Profile
    {
        public ObtenerSocioPorIdMapping()
        {
            CreateMap<Socio, ObtenerSocioPorIdResponse>()
                .ForMember( dest => dest.Id, opt => opt.MapFrom(src => src.id_socio))
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.nombre} {src.apel1}"))
                .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.dni));
        }
    }
}

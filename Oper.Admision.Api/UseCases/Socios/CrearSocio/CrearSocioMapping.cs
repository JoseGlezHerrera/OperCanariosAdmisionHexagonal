using AutoMapper;
using Oper.Admision.Application.UseCases.Socios.CrearSocio;

namespace Oper.Admision.Api.UseCases.Socios.CrearSocio
{
    public class CrearSocioMapping : Profile
    {
        public CrearSocioMapping()
        {
            CreateMap<CrearSocioRequest, CrearSocioInput>();
            CreateMap<CrearSocioOutput, CrearSocioResponse>();
        }
    }
    
}

using AutoMapper;
using Oper.Admision.Api.UsesCases.Sesiones.CrearSesion;
using Oper.Admision.Application.UseCases.Sesiones;
using Oper.Admision.Application.UseCases.Sesiones.CrearSesion;

namespace Oper.Admision.Api.UsesCases.Sesiones
{
    public class CrearSesionMapping : Profile
    {
        public CrearSesionMapping()
        {
            CreateMap<CrearSesionRequest, CrearSesionInput>();
            CreateMap<CrearSesionOutput, CrearSesionResponse>();

        }


    }
}

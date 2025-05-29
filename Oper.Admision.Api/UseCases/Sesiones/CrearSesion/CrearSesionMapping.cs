using AutoMapper;
using Oper.Admision.Application.UseCases.Sesiones;
using Oper.Admision.Application.UseCases.Sesiones.CrearSesion;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Sesiones.CrearSesion
{
    public class CrearSesionMapping : Profile
    {
        public CrearSesionMapping()
        {
            CreateMap<CrearSesionRequest, CrearSesionInput>();
            CreateMap<CrearSesionInput, Sesion>();
            CreateMap<Sesion, CrearSesionOutput>();
        }
    }
}

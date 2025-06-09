using AutoMapper;
using Oper.Admision.Application.UseCases.Sesiones.GetSesion;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Sesiones.GetSesion
{
    public class GetSesionMapping : Profile
    {
        public GetSesionMapping()
        {
            CreateMap<Sesion, GetSesionOutput>();

            CreateMap<GetSesionOutput, GetSesionResponse>();
        }
    }
}
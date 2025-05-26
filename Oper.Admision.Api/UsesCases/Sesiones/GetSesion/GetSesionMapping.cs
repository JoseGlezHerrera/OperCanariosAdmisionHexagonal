using AutoMapper;
using Oper.Admision.Application.UseCases.Sesiones.GetSesion;

namespace Oper.Admision.Api.UsesCases.Sesiones.GetSesion
{
    public class GetSesionMapping : Profile
    {
        public GetSesionMapping()
        {
            CreateMap<GetSesionOutput, GetSesionResponse>();
        }
    }
}

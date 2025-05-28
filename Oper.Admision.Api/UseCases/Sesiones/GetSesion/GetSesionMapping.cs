using AutoMapper;
using Oper.Admision.Application.UseCases.Sesiones.GetSesion;

namespace Oper.Admision.Api.UseCases.Sesiones.GetSesion
{
    public class GetSesionMapping : Profile
    {
        public GetSesionMapping()
        {
            CreateMap<GetSesionOutput, GetSesionResponse>();
        }
    }
}

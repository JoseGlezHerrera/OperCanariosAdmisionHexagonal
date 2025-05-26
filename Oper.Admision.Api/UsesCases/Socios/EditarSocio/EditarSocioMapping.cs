using AutoMapper;
using Oper.Admision.Application.UseCases.Socios.EditarSocio;
using Oper.Admision.Application.UseCases.Socios.EditarUsuario;

namespace Oper.Admision.Api.UsesCases.Socios.EditarSocio
{
    public class EditarSocioMapping : Profile
    {
        public EditarSocioMapping() 
        {
            CreateMap<EditarSocioRequest, EditarSocioInput>();
            CreateMap<EditarSocioOutput, EditarSocioResponse>();
        }
    }
}

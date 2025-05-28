using AutoMapper;
using Oper.Admision.Application.UseCases.Socios.EditarSocio;
using Oper.Admision.Application.UseCases.Socios.EditarUsuario;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Socios.EditarSocio
{
    public class EditarSocioMapping : Profile
    {
        public EditarSocioMapping() 
        {
            CreateMap<EditarSocioRequest, EditarSocioInput>();
            CreateMap<EditarSocioOutput, EditarSocioResponse>();
            CreateMap<Socio, EditarSocioOutput>();
        }
    }
}

using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.Editar;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Usuarios.EditarUsuario
{
    public class EditarUsuarioMapping : Profile
    {
        public EditarUsuarioMapping()
        {
            CreateMap<EditarUsuarioRequest, EditarUsuarioInput>();
            CreateMap<Usuario, EditarUsuarioOutput>();
            CreateMap<EditarUsuarioOutput, EditarUsuarioResponse>();
        }
    }
}
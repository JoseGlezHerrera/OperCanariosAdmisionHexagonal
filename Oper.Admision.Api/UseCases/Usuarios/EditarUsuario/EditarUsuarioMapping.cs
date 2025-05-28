using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.Editar;

namespace Oper.Admision.Api.UseCases.Usuarios.EditarUsuario
{
    public class GetEnlaceMapping : Profile
    {
        public GetEnlaceMapping()
        {
            CreateMap<EditarUsuarioRequest, EditarUsuarioInput>();
            CreateMap<EditarUsuarioOutput, EditarUsuarioResponse>();
        }
    }
}

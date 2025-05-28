using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.Crear;

namespace Oper.Admision.Api.UseCases.Usuarios.CrearUsuario
{
    public class CrearUsuarioMapping : Profile
    {
        public CrearUsuarioMapping()
        {
            CreateMap<CrearUsuarioRequest, CrearUsuarioInput>();
            CreateMap<CrearUsuarioOutput, CrearUsuarioResponse>();
        }
    }
}
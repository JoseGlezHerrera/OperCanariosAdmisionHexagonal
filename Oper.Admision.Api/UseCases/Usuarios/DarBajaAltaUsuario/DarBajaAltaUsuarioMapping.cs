using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.DarBajaAlta;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Usuarios.DarBajaAltaUsuario
{
    public class DarBajaAltaUsuarioMapping : Profile
    {
        public DarBajaAltaUsuarioMapping()
        {
            CreateMap<DarBajaAltaUsuarioRequest, DarBajaAltaUsuarioInput>();
            CreateMap<DarBajaAltaUsuarioOutput, DarBajaAltaUsuarioResponse>();
            CreateMap<Usuario, DarBajaAltaUsuarioOutput>();
        }
    }
}

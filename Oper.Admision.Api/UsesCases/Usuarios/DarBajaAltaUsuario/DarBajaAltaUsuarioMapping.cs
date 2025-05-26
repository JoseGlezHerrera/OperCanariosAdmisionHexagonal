using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.DarBajaAlta;

namespace Oper.Admision.Api.UseCases.Usuarios.DarBajaAltaUsuario
{
    public class DarBajaAltaUsuarioMapping : Profile
    {
        public DarBajaAltaUsuarioMapping()
        {
            CreateMap<DarBajaAltaUsuarioRequest, DarBajaAltaUsuarioInput>();
            CreateMap<DarBajaAltaUsuarioOutput, DarBajaAltaUsuarioResponse>();
        }
    }
}

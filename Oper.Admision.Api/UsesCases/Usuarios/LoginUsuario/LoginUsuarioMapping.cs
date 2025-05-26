using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.Login;

namespace Oper.Admision.Api.UseCases.Usuarios.LoginUsuario
{
    public class LoginUsuarioMapping : Profile
    {
        public LoginUsuarioMapping()
        {
            CreateMap<LoginUsuarioRequest, LoginUsuarioInput>();
            CreateMap<LoginUsuarioOutput, LoginUsuarioResponse>();
        }
    }
}

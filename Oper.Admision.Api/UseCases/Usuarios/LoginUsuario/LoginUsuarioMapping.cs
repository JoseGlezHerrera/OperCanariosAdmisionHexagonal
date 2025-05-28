using AutoMapper;
using Oper.Admision.Api.UseCases.Usuarios.LoginUsuario;
using Oper.Admision.Application.UseCases.Usuarios.Login;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Usuarios.LoginUsuario
{
    public class LoginUsuarioMapping : Profile
    {
        public LoginUsuarioMapping()
        {
            CreateMap<LoginUsuarioRequest, LoginUsuarioInput>();
            CreateMap<Usuario, LoginUsuarioOutput>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Alias, opt => opt.MapFrom(src => src.Alias))
                .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.RolId))
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId));
            CreateMap<LoginUsuarioOutput, LoginUsuarioResponse>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Alias, opt => opt.MapFrom(src => src.Alias))
                .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.RolId));
        }
    }
}
using AutoMapper;
using Oper.Admision.Api.UseCases.Usuarios.CrearUsuario;
using Oper.Admision.Application.UseCases.Usuarios.Crear;
using Oper.Admision.Domain.Models;

public class CrearUsuarioMapping : Profile
{
    public CrearUsuarioMapping()
    {
        CreateMap<CrearUsuarioRequest, CrearUsuarioInput>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        CreateMap<CrearUsuarioInput, Usuario>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
        CreateMap<Usuario, CrearUsuarioOutput>();
    }
}

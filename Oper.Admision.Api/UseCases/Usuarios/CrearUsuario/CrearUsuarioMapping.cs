using AutoMapper;
using Oper.Admision.Api.UseCases.Usuarios.CrearUsuario;
using Oper.Admision.Application.UseCases.Usuarios.Crear;
using Oper.Admision.Domain.Models; // <-- Aquí está tu Request

public class CrearUsuarioMapping : Profile
{
    public CrearUsuarioMapping()
    {
        CreateMap<CrearUsuarioRequest, CrearUsuarioInput>();
        CreateMap<CrearUsuarioInput, Usuario>();
        CreateMap<Usuario, CrearUsuarioOutput>();
    }
}

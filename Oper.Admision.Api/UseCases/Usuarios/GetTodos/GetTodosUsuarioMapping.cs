using AutoMapper;
using Oper.Admision.Api.UseCases.Usuarios.GetTodosUsuario;
using Oper.Admision.Application.UseCases.Usuarios.GetTodos;
using Oper.Admision.Domain.Models;

public class GetTodosUsuarioMapping : Profile
{
    public GetTodosUsuarioMapping()
    {
        CreateMap<Usuario, GetTodosUsuarioOutput>();
        CreateMap<GetTodosUsuarioOutput, GetTodosUsuarioResponse>();
    }
}

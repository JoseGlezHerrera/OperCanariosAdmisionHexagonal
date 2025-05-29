using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.GetTodos;
using Oper.Admision.Domain.Models;

public class GetTodosUsuarioMapping : Profile
{
    public GetTodosUsuarioMapping()
    {
        CreateMap<Usuario, GetTodosUsuarioOutput>();
    }
}

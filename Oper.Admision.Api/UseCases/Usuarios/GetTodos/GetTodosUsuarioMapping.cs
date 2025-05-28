using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.GetTodos;

namespace Oper.Admision.Api.UseCases.Usuarios.GetTodosUsuario
{
    public class GetTodosUsuarioMapping : Profile
    {
        public GetTodosUsuarioMapping()
        {
            CreateMap<GetTodosUsuarioOutput, GetTodosUsuarioResponse>();
        }
    }
}

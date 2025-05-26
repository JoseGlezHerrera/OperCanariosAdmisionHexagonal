using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.GetTodos;

namespace Oper.Admision.Application.UseCases.Usuarios.GetTodos
{
    public class GetTodosUsuarioMapping : Profile
    {
        public GetTodosUsuarioMapping()
        {
            CreateMap<Domain.Models.Usuario, GetTodosUsuarioOutput>()
             .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni));

        }
    }
}

using AutoMapper;
using Oper.Admision.Api.UseCases.Usuarios.GetTodosUsuario;
using Oper.Admision.Application.UseCases.Socios.GetSocio;
using Oper.Admision.Application.UseCases.Usuarios.GetTodos;

namespace Oper.Admision.Api.UsesCases.Socios.GetSocio
{
    public class GetSocioMapping : Profile
    {
        public GetSocioMapping()
        {
            CreateMap<GetSocioOutput, GetSocioResponse>();
        }
    }
}

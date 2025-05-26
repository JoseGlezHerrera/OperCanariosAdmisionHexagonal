using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.Login;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Application.UseCases.Usuarios.Login
{
    public class EditarUsuarioMapping : Profile
    {
        public EditarUsuarioMapping()
        {
            CreateMap<Usuario, LoginUsuarioOutput>();
            CreateMap<LoginUsuarioInput,Usuario>();

        }
    }
}

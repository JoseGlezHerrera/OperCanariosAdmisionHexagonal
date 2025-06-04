using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.CambiarPassword;
using Oper.Admision.Api.UseCases.Usuarios.CambiarPasswordUsuario;

namespace Oper.Admision.Api.UseCases.Usuarios.CambiarPasswordUsuario
{
    public class CambiarPasswordUsuarioMapping : Profile
    {
        public CambiarPasswordUsuarioMapping()
        {
            CreateMap<CambiarPasswordUsuarioRequest, CambiarPasswordUsuarioInput>();
        }
    }
}
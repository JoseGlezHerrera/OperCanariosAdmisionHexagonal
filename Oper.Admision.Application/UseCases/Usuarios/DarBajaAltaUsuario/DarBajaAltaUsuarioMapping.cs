using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.DarBajaAlta;

namespace Oper.Admision.Application.UseCases.Usuarios.DarBajaAlta
{
    public class DarBajaAltaUsuarioMapping : Profile
    {
        public DarBajaAltaUsuarioMapping()
        {
            CreateMap<Domain.Models.Usuario, DarBajaAltaUsuarioOutput>();
            CreateMap<DarBajaAltaUsuarioInput, Domain.Models.Usuario>();

        }
    }
}

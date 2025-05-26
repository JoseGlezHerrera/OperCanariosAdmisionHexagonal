using AutoMapper;
using Oper.Admision.Application.UseCases.Usuarios.Crear;

namespace Oper.Admision.Application.UseCases.Usuarios.Crear
{
    public class EditarUsuarioMapping : Profile
    {
        public EditarUsuarioMapping()
        {
            CreateMap<Domain.Models.Usuario, CrearUsuarioOutput>();
            CreateMap<CrearUsuarioInput,Domain.Models.Usuario>();

        }
    }
}

using AutoMapper;

namespace Oper.Admision.Application.UseCases.Usuarios.Editar
{
    public class EditarUsuarioMapping : Profile
    {
        public EditarUsuarioMapping()
        {
            CreateMap<EditarUsuarioInput, Domain.Models.Usuario>();

            CreateMap<Domain.Models.Usuario, EditarUsuarioOutput>();

        }
    }
}

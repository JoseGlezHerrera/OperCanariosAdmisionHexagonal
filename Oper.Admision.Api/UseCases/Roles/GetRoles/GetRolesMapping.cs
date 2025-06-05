using AutoMapper;
using Oper.Admision.Application.UseCases.Rol.GetRoles;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UseCases.Roles.GetRoles
{
    public class GetRolesMapping : Profile
    {
        public GetRolesMapping()
        {
            CreateMap<GetRolesOutput, GetRolesResponse>();
            CreateMap<Rol, GetRolesOutput>();
            CreateMap<Rol, GetRolesOutput>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RolId));
        }
    }
}
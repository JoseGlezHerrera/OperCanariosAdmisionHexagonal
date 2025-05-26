using AutoMapper;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Sesiones.GetSesion
{
    public class GetSesionMapping : Profile
    {
        public GetSesionMapping()
        {
            CreateMap<Sesion, GetSesionOutput>()
                .ForMember(dest => dest.id_sesion, opt => opt.MapFrom(src => src.id_sesion));
        }
    }
}

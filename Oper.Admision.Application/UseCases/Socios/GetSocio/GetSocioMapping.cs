using AutoMapper;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.GetSocio
{
    public class GetSocioMapping : Profile
    {
        public GetSocioMapping()
        {
            CreateMap<Socio, GetSocioOutput>()
                .ForMember(dest => dest.dni, opt => opt.MapFrom(src => src.dni));

        }
    }
    
}


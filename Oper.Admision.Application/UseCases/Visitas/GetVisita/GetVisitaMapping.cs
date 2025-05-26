using AutoMapper;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.GetVisita
{
    public class GetVisitaMapping : Profile
    {
        public GetVisitaMapping()
        {
            CreateMap<Visita, GetVisitaOutPut>()
                .ForMember(dest => dest.id_visita, opt => opt.MapFrom(src => src.id_visita));
        }
    }
}

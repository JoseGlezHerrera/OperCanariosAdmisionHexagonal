using AutoMapper;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.CrearSocio
{
    public class CrearSocioMapping : Profile
    {
        public CrearSocioMapping()
        {
            CreateMap<Socio, CrearSocioOutput>();
            CreateMap<CrearSocioOutput, Socio>();
            CreateMap<CrearSocioInput, Socio>();

        }
    }
}

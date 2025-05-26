using AutoMapper;
using Oper.Admision.Application.UseCases.Sesiones.CrearSesion;
using Oper.Admision.Application.UseCases.Socios.CrearSocio;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Sesiones
{
    public class CrearSesionMapping : Profile
    {
        public CrearSesionMapping()
        {
            CreateMap<Sesion, CrearSesionOutput>();
            CreateMap<CrearSesionOutput, Sesion>();
            CreateMap<CrearSesionInput, Sesion>();
        }
    }
}

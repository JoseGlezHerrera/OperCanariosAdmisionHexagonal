using AutoMapper;
using Oper.Admision.Application.UseCases.Socios.EditarUsuario;
using Oper.Admision.Application.UseCases.Usuarios.Editar;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.EditarSocio
{
    class EditarSocioMapping : Profile
    {
        public EditarSocioMapping()
        {
            CreateMap<Socio, EditarSocioOutput>();
            CreateMap<EditarSocioOutput, Socio>();

        }
    }
}


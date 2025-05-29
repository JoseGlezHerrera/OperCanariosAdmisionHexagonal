using AutoMapper;
using Oper.Admision.Application.UseCases.Socios.EliminarSocio;
using Oper.Admision.Domain.Models;

public class EliminarSocioMapping : Profile
{
    public EliminarSocioMapping()
    {
        CreateMap<EliminarSocioInput, Socio>();
    }
}
using AutoMapper;
using Oper.Admision.Api.UseCases.Problematicos.ActualizarProblematico;
using Oper.Admision.Application.UseCases.Problematico.ActualizarProblematico;

namespace Oper.Admision.Api.UseCases.Problematicos.ActualizarProblematico
{
    public class ActualizarProblematicoMapping : Profile
    {
        public ActualizarProblematicoMapping()
        {
            CreateMap<ActualizarProblematicoRequest, ActualizarProblematicoInput>();
        }
    }
}
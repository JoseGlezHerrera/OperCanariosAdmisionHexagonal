using AutoMapper;
using Oper.Admision.Application.UseCases.Problematico.CrearProblematico;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Api.UsesCases.Problematicos
{

   public class CrearProblematicoMapping
    {
        public static CrearProblematicoResponse MapToResponse(Problematico problematico)
        {
            return new CrearProblematicoResponse
            {
                FechaCreacion = problematico.fecha_crea ?? DateTime.MinValue,
                Dni = problematico.id_socio.ToString(),
                Regla = problematico.regla,
                Comentario = problematico.comentario,
                TipoProblematico = GetTipoProblematico(problematico)
            };
        }
        private static int GetTipoProblematico(Problematico problematico)
        {
            if (problematico.conflictivo) return 3;
            if (problematico.prohibida_entrada) return 2;
            if (problematico.gobcan) return 1;
            return 0; // Default value if none match 1: gobcan, 2: Prohibida Entrada, 3: conflictivo
        }
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CrearProblematicoRequest, CrearProblematicoInput>();
            cfg.CreateMap<Problematico, CrearProblematicoResponse>();
        }
    }
}
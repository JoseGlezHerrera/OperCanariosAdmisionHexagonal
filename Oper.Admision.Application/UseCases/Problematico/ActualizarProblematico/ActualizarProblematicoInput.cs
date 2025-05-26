using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Problematico.ActualizarProblematico
{
    public record ActualizarProblematicoInput
    {
        public int Id { get; init; }
        public string Tipo { get; init; } = string.Empty;
        public string Observaciones { get; init; } = string.Empty;
    }


}

using Oper.Admision.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Socios.ValidarSocio
{
    public class ValidarSocioUseCase
    {
        private readonly ISocioRepository _socioRepository;
        public ValidarSocioUseCase(ISocioRepository socioRepository)
        {
            _socioRepository = socioRepository;
        }
        public (bool esValido, string mensaje) Execute (string dni, string nombre, int? socioId)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return (false, "El DNI es obligatorio.");
            if (string.IsNullOrWhiteSpace(nombre))
                return (false, "El nombre es obligatorio.");
            if (socioId.HasValue)
            {
                var socioExistente = _socioRepository.Get(socioId.Value);
                if (socioExistente == null)
                    return (false, $"No existe ningún socio con ID {socioId.Value}.");
                if (!socioExistente.dni?.Equals(dni, StringComparison.OrdinalIgnoreCase) ?? true)
                    return (false, $"El DNI proporcionado no coincide con el socio ID {socioId.Value}.");

                if (!socioExistente.nombre?.Equals(nombre, StringComparison.OrdinalIgnoreCase) ?? true)
                    return (false, $"El nombre proporcionado no coincide con el socio ID {socioId.Value}.");
            }
            var existeDni = _socioRepository.GetByDniAsync(dni).Result;
            if (existeDni != null && (!socioId.HasValue ||existeDni.id_socio != socioId))
            {
                return (false, "Ya existe un socio con este DNI.");
            }
            var existeNombre = _socioRepository.ExisteNombre(socioId, nombre);
            if (existeNombre)
                return (false, "Ya existe un socio con este nombre.");
                return (true, "El socio es válido.");

        }
    }
}
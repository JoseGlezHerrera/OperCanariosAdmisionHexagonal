using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Visitas.RegistrarVisita
{
    public class RegistrarVisitaUseCase
    {
        private readonly ISocioRepository _socioRepository;
        private readonly ISesionRepository _sesionRepository;
        private readonly IVisitaRepository _visitaRepository;
        public RegistrarVisitaUseCase(
            ISocioRepository socioRepository,
            ISesionRepository sesionRepository,
            IVisitaRepository visitaRepository)
        {
            _socioRepository = socioRepository;
            _sesionRepository = sesionRepository;
            _visitaRepository = visitaRepository;
        }
        public (bool registrado, DateTime fecha, string mensaje) Execute (int socioId, int sesionId)
        {
            var socio = _socioRepository.Get(socioId);
            var sesion = _sesionRepository.Get(sesionId);
            if (socio == null || sesion == null)
                return (false, DateTime.MinValue, "Socio o sesión no encontrada.");
            bool haVisitado = _visitaRepository.ExisteVisita(socioId, sesionId);
            if (!haVisitado)
            {
                var difDias = DateTime.Now.Subtract(socio.fecha_alta ?? DateTime.MinValue).Days;
                if (difDias > 0) sesion.habituales++;
                else sesion.nuevos++;
                if (socio.sexo == false) sesion.hombres++;
                else sesion.mujeres++;
                _sesionRepository.Update(sesion);
            }
            var visita = new Oper.Admision.Domain.Models.Visita
            {
                id_socio = socioId,
                id_sesion = sesionId,
                fecha_hora = DateTime.Now
            };
            _visitaRepository.Registrar(visita);
            return (true, visita.fecha_hora, "Visita registrada correctamente.");
        }
    }
}

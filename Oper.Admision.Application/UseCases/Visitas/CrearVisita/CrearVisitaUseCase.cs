using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Oper.Admision.Application.Exceptions;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain;

namespace Oper.Admision.Application.UseCases.Visitas.CrearVisita
{
    public class CrearVisitaUseCase
    {
        private readonly IVisitaRepository _visitaRepository;
        private readonly ISocioRepository _socioRepository;
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;

        public CrearVisitaUseCase(
            IVisitaRepository visitaRepository,
            ISocioRepository socioRepository,
            IMapper mapper,
            IGestionUOW uow
        )
        {
            _visitaRepository = visitaRepository;
            _socioRepository = socioRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<CrearVisitaOutput> EjecutarAsync(CrearVisitaInput input)
        {
            var socioExiste = await _socioRepository.ExisteAsync(input.SocioId);
            if (!socioExiste)
                throw new ArgumentInputException($"El socio con ID {input.SocioId} no existe.");

            try
            {
                var visita = _mapper.Map<Oper.Admision.Domain.Models.Visita>(input);
                await _visitaRepository.AgregarAsync(visita);
                await _uow.SaveChangesAsync();

                var output = _mapper.Map<CrearVisitaOutput>(visita);
                return output;
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("FK_visitas_sesiones_id_sesion") == true)
            {
                throw new ArgumentInputException("No se puede crear la visita: la sesión especificada no existe o no es válida.");
            }
            catch (Exception ex)
            {
                throw new ArgumentInputException("Ha ocurrido un error al guardar la visita. Detalles: " + ex.Message);
            }
        }
    }
}
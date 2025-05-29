using AutoMapper;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain;

namespace Oper.Admision.Application.UseCases.Visitas.CrearVisita
{
    public class CrearVisitaUseCase
    {
        private readonly IVisitaRepository _visitaRepository;
        private readonly IMapper _mapper;
        private readonly IGestionUOW _uow;

        public CrearVisitaUseCase(
            IVisitaRepository visitaRepository,
            IMapper mapper,
            IGestionUOW uow
        )
        {
            _visitaRepository = visitaRepository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<CrearVisitaOutput> EjecutarAsync(CrearVisitaInput input)
        {
            try
            {
                var visita = _mapper.Map<Oper.Admision.Domain.Models.Visita>(input);
                await _visitaRepository.AgregarAsync(visita);
                await _uow.SaveChangesAsync();

                var output = _mapper.Map<CrearVisitaOutput>(visita);
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR al guardar visita → " + (ex.InnerException?.Message ?? ex.Message), ex);
            }
        }

    } 
}
using AutoMapper;
using Oper.Admision.Application.UseCases.Visitas.CrearVisita;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Application.UseCases.Visitas.CrearVisita;

public class CrearVisitaUseCase
{
    private readonly IVisitaRepository _repository;
    private readonly IMapper _mapper;

    public CrearVisitaUseCase(IVisitaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Visita> EjecutarAsync(CrearVisitaInput input)
    {
        var entidad = _mapper.Map<Visita>(input);
        await _repository.AgregarAsync(entidad);
        return entidad;
    }
}
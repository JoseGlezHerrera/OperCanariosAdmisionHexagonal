using AutoMapper;
using Oper.Admision.Application.UseCases.Problematico.CrearProblematico;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Models;
using static Oper.Admision.Domain.Models.Problematico;

public class CrearProblematicoUseCase
{
    private readonly IProblematicoRepository _repo;
    private readonly ISocioRepository _socioRepo;
    private readonly IMapper _mapper;

    public CrearProblematicoUseCase(IProblematicoRepository repo, ISocioRepository socioRepo, IMapper mapper)
    {
        _repo = repo;
        _socioRepo = socioRepo;
        _mapper = mapper;
    }

    public async Task<Problematico> ExecuteAsync(CrearProblematicoInput input)
    {
        Validar(input);

        var socio = await _socioRepo.GetByDniAsync(input.Dni);
        if (socio == null)
            throw new Exception($"No se encontró un socio con DNI {input.Dni}");

        var problematico = new Problematico
        {
            id_socio = socio.id_socio, // Usamos el ID real
            id_sesion = input.IdSesion,
            id_sede = input.IdSede,
            fecha_crea = input.FechaCreacion,
            regla = input.Regla,
            comentario = input.Comentario,
            visible = true,
            conflictivo = input.TipoProblematico == (int)TipoProblematicoEnum.Conflictivo,
            prohibida_entrada = input.TipoProblematico == (int)TipoProblematicoEnum.ProhibidaEntrada,
            gobcan = input.TipoProblematico == (int)TipoProblematicoEnum.Gobcan
        };

        return await _repo.InsertarProblematicoAsync(problematico, socio);
    }
    private void Validar(CrearProblematicoInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Dni))
            throw new ArgumentException("El DNI es obligatorio.");

        if (string.IsNullOrWhiteSpace(input.Regla))
            throw new ArgumentException("La regla es obligatoria.");

        if (input.TipoProblematico < 1 || input.TipoProblematico > 3)
            throw new ArgumentException("TipoProblematico inválido.");
    }


}

using Exercicio4.Application.Dtos;
using Exercicio4.Application.Interfaces;
using Exercicio4.Domain.Entities;
using Exercicio4.Domain.Interfaces;

namespace Exercicio4.Application.Services;

public class MateriaService : IMateriaService
{
    private readonly IRepository<Materia> _materiaRepository;

    public MateriaService(IRepository<Materia> materiaRepository)
    {
        _materiaRepository = materiaRepository;
    }

    public async Task<Materia> Cadastrar(MateriaDto materiaDto)
    {
        try
        {
            var materia = new Materia
            {
                Nome = materiaDto.Nome
            };

            await _materiaRepository.SalvarAsync(materia);
            return materia;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Erro ao cadastrar matéria", e);
        }
    }

    public async Task<List<Materia>> Listar()
    {
        try
        {
            var materias = await _materiaRepository.ListarAsync();
            return materias;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Erro ao listar matérias", e);
        }
    }

    public async Task<Materia> BuscarPorId(int materiaId)
    {
        try
        {
            var materia = await _materiaRepository.BuscarAsync(materiaId);
            return materia;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Erro ao buscar matéria", e);
        }
    }
}
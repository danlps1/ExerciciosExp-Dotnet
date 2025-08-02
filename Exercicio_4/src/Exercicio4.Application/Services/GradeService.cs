using Exercicio4.Application.Dtos;
using Exercicio4.Application.Interfaces;
using Exercicio4.Domain.Entities;
using Exercicio4.Domain.Interfaces;
using Exercicio4.Infrastructure.Repositories.Interfaces;

namespace Exercicio4.Application.Services;

public class GradeService : IGradeService
{
    private readonly IGradeRepository _gradeRepository;
    private readonly IMateriaRepository _materiaRepository;

    public GradeService(IGradeRepository gradeRepository, IMateriaRepository materiaRepository)
    {
        _gradeRepository = gradeRepository;
        _materiaRepository = materiaRepository;
    }

    public async Task<Grade> Cadastrar(GradeDto gradeDto)
    {
        try
        {
            if (gradeDto.MateriasId.Count < 5)
            {
                throw new ApplicationException("Uma grade deve possuir no mínimo 5 materias");
            }

            var listaMaterias = await _materiaRepository.BuscarListaPorIds(gradeDto.MateriasId);


            var grade = new Grade()
            {
                Materias = listaMaterias
            };

            await _gradeRepository.SalvarAsync(grade);
            return grade;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Erro ao cadastrar grade", e);
        }
    }

    public async Task<List<Grade>> Listar()
    {
        try
        {
            var grades = await _gradeRepository.ListarAsync();
            return grades;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Erro ao listar grades", e);
        }
    }

    public async Task<Grade> BuscarPorId(int materiaId)
    {
        try
        {
            var grade = await _gradeRepository.BuscarAsync(materiaId);
            return grade;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Erro ao buscar grade", e);
        }
    }
}
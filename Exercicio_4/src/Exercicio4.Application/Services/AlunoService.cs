using Exercicio4.Application.Dtos;
using Exercicio4.Application.Interfaces;
using Exercicio4.Domain.Entities;
using Exercicio4.Domain.Interfaces;
using Exercicio4.Infrastructure.Repositories.Interfaces;

namespace Exercicio4.Application.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly IGradeRepository _gradeRepository;

    public AlunoService(IAlunoRepository alunoRepository, IGradeRepository gradeRepository)
    {
        _alunoRepository = alunoRepository;
        _gradeRepository = gradeRepository;
    }


    public async Task<Aluno> Cadastrar(AlunoDto alunoDto)
    {
        try
        {
            var grade = await _gradeRepository.BuscarAsync(alunoDto.GradeId);

            var aluno = new Aluno()
            {
                Nome = alunoDto.Nome,
                GradeId = alunoDto.GradeId,
                Grade = grade
            };

            await _alunoRepository.SalvarAsync(aluno);
            return aluno;
        }
        catch (Exception e)
        {
            throw new ArgumentException("Erro ao cadastrar aluno", e);
        }
    }

    public async Task<List<Aluno>> Listar()
    {
        try
        {
            var alunos = await _alunoRepository.ListarAsync();
            return alunos;
        }
        catch (Exception e)
        {
            throw new ArgumentException("Erro ao listar alunos", e);
        }
    }

    public async Task<Aluno> BuscarPorId(int? alunoId)
    {
        try
        {
            var aluno = await _alunoRepository.BuscarAsync(alunoId.Value);
            return aluno;
        }
        catch (Exception e)
        {
            throw new ArgumentException("Erro ao buscar aluno", e);
        }
    }
}
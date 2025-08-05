using Exercicio4.Application.Dtos;
using Exercicio4.Domain.Entities;

namespace Exercicio4.Application.Interfaces;

public interface IAlunoService
{
    Task<Aluno> Cadastrar(AlunoDto alunoDto);
    Task<List<Aluno>> Listar();
    Task<Aluno> BuscarPorId(int? alunoId);
}
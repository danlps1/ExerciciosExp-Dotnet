using Exercicio4.Application.Dtos;
using Exercicio4.Domain.Entities;

namespace Exercicio4.Application.Interfaces;

public interface IGradeService
{
    Task<Grade> Cadastrar(GradeDto gradeDto);
    Task<List<Grade>> Listar();
    Task<Grade> BuscarPorId(int gradeId);
}   
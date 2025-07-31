using Exercicio4.Application.Dtos;
using Exercicio4.Domain.Entities;

namespace Exercicio4.Application.Interfaces;

public interface IMateriaService
{
    Task<Materia> Cadastrar(MateriaDto materiaDto);
    Task<List<Materia>> Listar();
    Task<Materia> BuscarPorId(int materiaId);
}
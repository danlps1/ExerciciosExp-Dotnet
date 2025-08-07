using Exercicio4.Domain.Entities;
using Exercicio4.Domain.Interfaces;

namespace Exercicio4.Infrastructure.Repositories.Interfaces;

public interface INotaRepository : IRepository<Nota>
{
    Task<List<Nota>> BuscarPorMateria(int materiId, int alunoId);
}
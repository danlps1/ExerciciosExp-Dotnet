using Exercicio4.Domain.Entities;
using Exercicio4.Domain.Interfaces;

namespace Exercicio4.Infrastructure.Repositories.Interfaces;

public interface IMateriaRepository : IRepository<Materia>
{
    Task<List<Materia>> BuscarListaPorIds(List<int> materiasIds);
}
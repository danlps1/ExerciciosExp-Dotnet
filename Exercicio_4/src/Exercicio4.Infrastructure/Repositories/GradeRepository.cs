using Exercicio4.Domain.Entities;
using Exercicio4.Domain.Interfaces;

namespace Exercicio4.Infrastructure.Repositories;

public class GradeRepository : IRepository<Grade>
{
    public Task SalvarAsync(Grade entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<Grade>> ListarAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Grade> BuscarAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task EditarAsync(Grade entity)
    {
        throw new NotImplementedException();
    }

    public Task DeletarAsync(int id)
    {
        throw new NotImplementedException();
    }
}
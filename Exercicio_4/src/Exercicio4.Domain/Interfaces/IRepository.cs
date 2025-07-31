namespace Exercicio4.Domain.Interfaces;

public interface IRepository<T>
{
    Task SalvarAsync(T entity);
    Task<List<T>> ListarAsync();
    Task<T> BuscarAsync(int id);
    
}
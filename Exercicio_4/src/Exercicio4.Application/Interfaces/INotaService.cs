using Exercicio4.Application.Dtos;
using Exercicio4.Domain.Entities;

namespace Exercicio4.Application.Interfaces;

public interface INotaService
{
    Task<List<Nota>> Cadastrar(NotaDto nota);
}
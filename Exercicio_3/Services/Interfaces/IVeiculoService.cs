using Exercicio_3.Entities;
using Exercicio_3.Services.Dtos;

namespace Exercicio_3.Services.Interfaces;

public interface IVeiculoService
{
    public Task<Veiculo> CadastrarVeiculo(VeiculoDto veiculo);
    public Task<List<Veiculo>> ListarVeiculos();
    public Task<Veiculo> BuscarVeiculoPorId(int veiculoId);
    public Task<Veiculo> EditarVeiculo(int veiculoId, VeiculoDto veiculo);
    public Task<String> DeletarVeiculo(int veiculoId);
}
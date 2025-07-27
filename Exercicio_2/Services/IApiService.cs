using Exercicio_2.Services.Dto;

namespace Exercicio_2.Services;

public interface IApiService
{
    public VeiculoDto BuscarVeiculoPorId(int veiculoId);
    public VeiculoDto SalvarVeiculo(VeiculoDto veiculo);
    public VeiculoDto DeletarVeiculo(int veiculoId);
    public VeiculoDto EditarVeiculo(int veiculoId);
    public MarcaDto CadastrarMarca(MarcaDto marca);
}
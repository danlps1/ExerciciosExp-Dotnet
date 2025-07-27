using Exercicio_2.Services.Dto;

namespace Exercicio_2.Services;

public interface IApiService
{
    public ResponseVeiculoDto BuscarVeiculoPorId(int veiculoId);
    public ResponseVeiculoDto SalvarVeiculo(VeiculoDto veiculo);
    public ResponseVeiculoDto DeletarVeiculo(int veiculoId);
    public ResponseVeiculoDto EditarVeiculo(int veiculoId);
    public ResponseMarcaDto CadastrarMarca(MarcaDto marca);
}
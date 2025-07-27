using Exercicio_2.Services.Dto;

namespace Exercicio_2.Services;

public class ApiService : IApiService
{
    private List<MarcaDto> _listaMarca = new List<MarcaDto>();

    public VeiculoDto BuscarVeiculoPorId(int veiculoId)
    {
        throw new NotImplementedException();
    }

    public VeiculoDto SalvarVeiculo(VeiculoDto veiculo)
    {
        throw new NotImplementedException();
    }

    public VeiculoDto DeletarVeiculo(int veiculoId)
    {
        throw new NotImplementedException();
    }

    public VeiculoDto EditarVeiculo(int veiculoId)
    {
        throw new NotImplementedException();
    }

    public MarcaDto CadastrarMarca(MarcaDto marca)
    {
        MarcaDto novaMarca = new MarcaDto();
        try
        {
            novaMarca.Id = _listaMarca.Count + 1;
            novaMarca.Nome = marca.Nome;
            _listaMarca.Add(novaMarca);

            return novaMarca;
        }
        catch (Exception e)
        {
            throw new ArgumentException("Erro ao cadastrar Marca: " + e.Message);
        }
    }
}
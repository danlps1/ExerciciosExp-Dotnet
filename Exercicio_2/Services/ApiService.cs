using Exercicio_2.Services.Dto;

namespace Exercicio_2.Services;

public class ApiService : IApiService
{
    private readonly List<ResponseMarcaDto> _listaMarca = [];
    private readonly List<ResponseVeiculoDto> _listVeiculo = [];

    public ResponseVeiculoDto BuscarVeiculoPorId(int veiculoId)
    {
        ResponseVeiculoDto responseVeiculo = new ResponseVeiculoDto();

        try
        {
            var veiculo = _listVeiculo.FirstOrDefault(v => v.Id == veiculoId);

            responseVeiculo = veiculo ?? throw new BadHttpRequestException("Veículo não encontrado");

            return responseVeiculo;
        }
        catch (Exception e)
        {
            throw new ArgumentException("Erro ao salvar Veículo: " + e.Message);
        }
    }

    public ResponseVeiculoDto SalvarVeiculo(VeiculoDto veiculo)
    {
        ResponseVeiculoDto novoVeiculo = new ResponseVeiculoDto();

        try
        {
            var marca = _listaMarca.FirstOrDefault(m => m.Id == veiculo.MarcaId);
            if (marca == null)
            {
                throw new BadHttpRequestException("Marca não encontrada");
            }

            novoVeiculo.Id = _listVeiculo.Count + 1;
            novoVeiculo.Nome = veiculo.Nome;
            novoVeiculo.Placa = veiculo.Placa;
            novoVeiculo.Marca = marca;
            _listVeiculo.Add(novoVeiculo);

            return novoVeiculo;
        }
        catch (Exception e)
        {
            throw new ArgumentException("Erro ao salvar Veículo: " + e.Message);
        }
    }

    public ResponseVeiculoDto DeletarVeiculo(int veiculoId)
    {
        ResponseVeiculoDto veiculoDeletado = new ResponseVeiculoDto();

        try
        {
            var veiculo = BuscarVeiculoPorId(veiculoId);
            _listVeiculo.Remove(veiculo);

            return veiculo;
        }
        catch (Exception e)
        {
            throw new ArgumentException("Erro ao deletar Veículo: " + e.Message);
        }
    }

    public ResponseVeiculoDto EditarVeiculo(int veiculoId)
    {
        throw new NotImplementedException();
    }

    public ResponseMarcaDto CadastrarMarca(MarcaDto marca)
    {
        ResponseMarcaDto novaMarca = new ResponseMarcaDto();

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
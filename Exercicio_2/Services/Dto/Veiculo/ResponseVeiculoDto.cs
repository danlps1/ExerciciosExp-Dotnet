namespace Exercicio_2.Services.Dto;

public class ResponseVeiculoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Placa { get; set; }
    public ResponseMarcaDto Marca { get; set; }
}